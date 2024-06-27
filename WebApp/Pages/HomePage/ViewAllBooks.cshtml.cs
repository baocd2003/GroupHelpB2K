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
    public class ViewAllBooksModel : PageModel
    {
        private readonly IBookManagementService _bookService;
        private readonly IPublisherService _publisherService;
        public ViewAllBooksModel(IBookManagementService bookService, IPublisherService publisherService)
        {
            _publisherService = publisherService;
            _bookService = bookService;
        }

        public IList<Book> Book { get; set; } = default!;
        public List<OrderDetail> cart;
        public IList<Publisher> Publishers { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 8;
        public int TotalPage { get; set; }
        public IActionResult OnGet()
        {
            var (bookList, pageCount) = _bookService.GetAvailableBooks(CurrentPage, ItemPerPage);
            Book = bookList;
            TotalPage = pageCount;
            Publishers = _publisherService.GetAll();
            return Page();
        }

        public IActionResult OnGetBooksByPublisher(int? id)
        {
            var (bookList, pageCount) = _bookService.GetBooksByPublisher((int)id,CurrentPage,ItemPerPage);
            Book = bookList;
            Publishers = _publisherService.GetAll();
            TotalPage = pageCount;
            return Page();
        }

        public IActionResult OnGetViewWaitingBooks()
        {
            var (bookList, pageCount) = _bookService.GetBookOutOfQuantity(CurrentPage, ItemPerPage);
            Book = bookList;
            Publishers = _publisherService.GetAll();
            TotalPage = pageCount;
            return Page();
        }
    }
}
