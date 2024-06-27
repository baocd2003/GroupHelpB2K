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
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.BookManagement
{
    public class IndexModel : StaffPageModel
    {
        private readonly IBookManagementService _bookService;

        public IndexModel(IBookManagementService bookService)
        {
           _bookService = bookService;
        }

        public IList<Book> Book { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 4;
        public int TotalPage { get; set; }
        public void OnGet()
        {
            var (bookList, pageCount) = _bookService.GetAvailableBooks(CurrentPage,ItemPerPage);
            Book = bookList;
            TotalPage = pageCount;
        }

        public IActionResult OnGetViewOutQuan()
        {
            var (bookList, pageCount) = _bookService.GetBookOutOfQuantity(CurrentPage, ItemPerPage);
            Book = bookList;
            TotalPage = pageCount;
            return Page();
        }

        public IActionResult OnGetViewOutAvai()
        {
            var (bookList, pageCount) = _bookService.GetBookNotAvailable(CurrentPage, ItemPerPage);
            Book = bookList;
            TotalPage = pageCount;
            return Page();
        }
    }
}
