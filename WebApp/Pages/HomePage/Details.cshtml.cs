using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using Services.Interface;

namespace WebApp.Pages.HomePage
{
    public class DetailsModel : PageModel
    {
        private readonly IBookManagementService _bookService;
        private readonly ICommentService _commentService;
        public DetailsModel(IBookManagementService bookService,ICommentService commentService)
        {
            _bookService = bookService;
            _commentService = commentService;
        }

        public Book Book { get; set; } = default!;
        public Comment? UserComment { get; set; }
        public List<Comment> OtherComments { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _bookService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
                if (int.TryParse(HttpContext.Session.GetString("CustomerId"), out int userId))
                {
                    UserComment = _commentService.GetUserCommentOnBook(userId, (int)id);
                } else
                {
                    UserComment = null;
                }
                
                OtherComments = _commentService.GetBookComments((int)id, 1, 10).commentList;
                OtherComments.Remove(UserComment);
            }
            return Page();
        }
        public IActionResult OnPostComment(int? bookId, string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                return OnGet(bookId);
            }
            if (int.TryParse(HttpContext.Session.GetString("CustomerId"), out int userId) == false)
            {
                return RedirectToPage("/Login");
            }
            if (_commentService.GetUserCommentOnBook(userId, (int)bookId) == null)
            {
                Comment newComment = new()
                {
                    BookId = (int)bookId,
                    CommentContent = comment,
                    CommentStatus = CommentStatus.Show,
                    UserId = userId,
                    Timestamp = DateTime.Now
                };
                _commentService.Add(newComment);
            }
            return OnGet(bookId);
        }
    }
}
