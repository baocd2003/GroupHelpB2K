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


namespace WebApp.Pages.HomePage
{
    public class AddCartModel : PageModel
    {
        public readonly IBookManagementService _bookService;
        public AddCartModel(IBookManagementService bookService)
        {
            _bookService = bookService;
        }
        private Dictionary<int, int>? cart;
        public void OnGet()
        {
            cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "Cart");
        }
        public IActionResult OnGetBuyNow(int id)
        {
            ProcessCart(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetBuyNowInDetails(int id)
        {
            ProcessCart(id);
            return RedirectToPage("./Details", new {id = id});
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            return RedirectToPage("./Index");
        }

        public void ProcessCart(int id)
        {
            cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            cart ??= new();
            Book book = _bookService.GetBookById(id);
            if (book == null || book.Quantity == 0 || book.IsAvailable == false)
            {
                return;
            }
            if (false == cart.TryGetValue(id, out var item))
            {
                cart.Add(id, 1);
            }
            int size = cart.Count;
            HttpContext.Session.SetString("size", size.ToString());
            CartSession.CartSession.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }
    }
}
