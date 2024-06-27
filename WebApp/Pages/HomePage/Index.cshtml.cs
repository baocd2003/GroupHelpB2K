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
    public class IndexModel : PageModel
    {
        private readonly IBookManagementService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;
        public IndexModel(IBookManagementService bookService, IPublisherService publisherService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _categoryService = categoryService;
        }

        public IList<Book> Book { get;set; } = default!;
        public IList<Publisher> Publishers { get;set; } = default!;
        public IList<Category> Categories { get;set; } = default!;  
        [BindProperty(SupportsGet = true)]
        public string query { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 8;
        public int TotalPage { get; set; }
        public void OnGet()
        {
            var (bookList, pageCount) = _bookService.GetAvailableBooks(CurrentPage,ItemPerPage);
            Book = bookList;
            TotalPage = pageCount;
            Publishers = _publisherService.GetAll();
            Categories = _categoryService.GetAll();
        }

        public IActionResult OnGetBooksByPublisher(int? id)
        {
            var (bookList, pageCount) = _bookService.GetBooksByPublisher((int)id, CurrentPage, ItemPerPage);
            Book = bookList;
            Publishers = _publisherService.GetAll();
            Categories = _categoryService.GetAll();
            TotalPage = pageCount;
            return Page();
        }

    }
}
