using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using WebApp.BaseModelPage;
using Repositories.Interface;
using Services.Interface;

namespace WebApp.Pages.HomePage
{
    public class ConfirmOrderModel : CustomerPageModel
    {

        private readonly IBookManagementService _bookService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public ConfirmOrderModel(IBookManagementService bookService, IUserService userService,IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _bookService = bookService;
            _userService = userService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        public IList<OrderDetail> OrderDetail { get; set; } = default!;
        public decimal TotalMoney { get; set; }
        private Dictionary<int, int>? cart;
        public IActionResult OnGet()
        {
            cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            OrderDetail = new List<OrderDetail>();
            if (cart == null)
            {
                return RedirectToPage("./Details");
            }
            foreach (var item in cart.Keys)
            {
                OrderDetail detail = new() { Book = _bookService.GetBookById(item), Quantity = cart[item], BookId = item };
                detail.Price = detail.Book.Price * detail.Quantity;
                OrderDetail.Add(detail);       
            }
            TotalMoney = OrderDetail.Select(x => x.Price).Sum();

            return Page();
        }

        public IActionResult OnPost()
        {
            int userId;
            if (false == int.TryParse(HttpContext.Session.GetString("CustomerId"), out userId)){
                return RedirectToPage("/Login");
            }
            if (string.IsNullOrWhiteSpace(Order.DeliveryAddress))
            {
                ModelState.AddModelError("", "Vui lòng thêm địa chỉ giao hàng");
                return Page();
            }
            if (string.IsNullOrEmpty(Order.PhoneNumber))
            {
                ModelState.AddModelError("", "Vui lòng thêm số điện thoại liên lạc");
                return Page();
            }
            cart = CartSession.CartSession.GetObjectFromJson<Dictionary<int, int>>(HttpContext.Session, "cart");
            List<OrderDetail> orderDetails = new();
            List<Book> orderedBook = new();
            foreach (var bookId in cart.Keys)
            {
                Book? currentBook = _bookService.GetBookById(bookId);
                if (currentBook.IsAvailable == false || currentBook.Quantity < cart[bookId])
                {
                    ModelState.AddModelError("","Số lượng sách trong kho không đủ, vui lòng kiểm tra lại đơn hàng");
                    return Page();
                }
                orderDetails.Add(new() { BookId = bookId,Price = currentBook.Price * cart[bookId],Quantity = cart[bookId] });
                currentBook.Quantity -= cart[bookId];
                orderedBook.Add(currentBook);
            }
            Order.OrderStatus = OrderStatus.Pending;
            Order.OrderDate = DateTime.Now;
            Order.UserId = userId;
            Order.TotalPrice = orderDetails.Select(x=>x.Price).Sum();
            _orderService.Add(Order);
            foreach (var item in orderDetails)
            {
                item.OrderId = Order.OrderId;
                _orderDetailService.Add(item);
            }
            foreach(var item in orderedBook)
            {
                _bookService.UpdateBook(item);
            }
            return RedirectToPage("./OrderHistory");
        }
    }
}
