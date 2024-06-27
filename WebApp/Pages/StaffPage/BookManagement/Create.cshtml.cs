using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using Services.Interface;

namespace WebApp.Pages.StaffPage.BookManagement
{
    public class CreateModel : PageModel
    {
        private readonly IBookManagementService _bookManagementService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IBookManagementService bookManagementService,IPublisherService publisherService, ICategoryService categoryService)
        {
            _bookManagementService = bookManagementService;
            _publisherService = publisherService;
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName");
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAll(), "PublisherId", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        [HiddenInput]
        public string ImagePath { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _bookManagementService.AddBook(Book);
            return RedirectToPage("./Index");
        }
    }
}
