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
    public class DeleteModel : StaffPageModel
    {
        private readonly IBookManagementService _bookService;

        public DeleteModel(IBookManagementService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
      public Book Book { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBookById((int)id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _bookService.GetBookById((int)id);

            if (book != null)
            {
                Book = book;
                book.IsAvailable = false;
                _bookService.UpdateBook(book);
            }

            return RedirectToPage("./Index");
        }
    }
}
