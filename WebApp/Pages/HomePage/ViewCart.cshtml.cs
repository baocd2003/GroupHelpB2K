using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using System.Net;
using System.Text.Json;
using Services.Interface;

namespace WebApp.Pages.HomePage
{
    public class ViewCartModel : PageModel
    {
        private readonly IBookManagementService _bookService;
        private readonly IPublisherService _publisherService;
        public ViewCartModel(IBookManagementService bookService, IPublisherService publisherService = null)
        {
            _bookService = bookService;
            _publisherService = publisherService;
        }
        public IList<OrderDetail> OrderDetail { get;set; }
        public IList<Publisher> Publishers { get; set; } = default!;
        public decimal Total { get; set; }
        public IActionResult OnGet()
        {
            var cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            OrderDetail = new List<OrderDetail>();
            if (cart != null)
            {
                foreach (var bookId in cart.Keys)
                {
                    OrderDetail detail = new() { Book = _bookService.GetBookById(bookId), Quantity = cart[bookId], BookId = bookId };
                    detail.Price = detail.Book.Price * detail.Quantity;
                    OrderDetail.Add(detail);
                }
            }
            Publishers = _publisherService.GetAll();
            Total = OrderDetail.Select(x=>x.Price).Sum();
            return Page();
        }
       
        public IActionResult OnPostUpdateQuan()
        {
            string[] bookIdsStringArray = JsonSerializer.Deserialize<string[]>(Request.Form["bookIds"].ToString());
            string[] quantityStringArray = JsonSerializer.Deserialize<string[]>(Request.Form["quantity"].ToString());
            // Convert string arrays to int arrays
            int[] bookIds = Array.ConvertAll(bookIdsStringArray, int.Parse);
            int[] quantity = Array.ConvertAll(quantityStringArray, int.Parse);
            var cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            if (bookIds.Length !=  quantity.Length || cart == null)
            {
                return OnGet();
            }
            for (int i = 0;i < bookIds.Length; i++)
            {
                if (false == cart.ContainsKey(bookIds[i]) || quantity[i] <1)
                {
                    continue;
                }
                int maxQuantity = _bookService.GetBookById(bookIds[i])?.Quantity??0;
                int newQuantity = maxQuantity < quantity[i] ? maxQuantity : quantity[i];
                if (newQuantity == 0)
                {
                    cart.Remove(bookIds[i]);
                }
                else
                {
                    cart[bookIds[i]] = newQuantity;
                }
            }
            CartSession.CartSession.SetObjectAsJson(HttpContext.Session, "cart", cart);
            int size = cart.Count;
            HttpContext.Session.SetString("size", size.ToString());
            return OnGet();
        }

        public IActionResult OnGetDeleteCart(int id)
        {
            var cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            if (cart != null && cart.ContainsKey(id))
            {
                cart.Remove(id);
                CartSession.CartSession.SetObjectAsJson(HttpContext.Session, "cart", cart);
                int size = cart.Count;
                HttpContext.Session.SetString("size", size.ToString());
            }
            return OnGet();
        }

        public IActionResult OnGetCheckConfirm()
        {
            var cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            if (cart != null && cart.Count > 0)
            {
                return RedirectToPage("./ConfirmOrder");
            }
            return OnGet();
        }
    }
}
