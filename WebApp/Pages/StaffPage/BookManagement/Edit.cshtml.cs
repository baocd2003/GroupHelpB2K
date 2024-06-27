using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.BookManagement
{
    public class EditModel : StaffPageModel
    {
        private readonly IBookManagementService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;
        public EditModel(IBookManagementService bookService, IPublisherService publisherService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _bookService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
           ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
           ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "PublisherId", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _bookService.UpdateBook(Book);
            return RedirectToPage("./Index");
        }

       
    }
}
