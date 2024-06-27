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

namespace WebApp.Pages.HomePage
{
    public class OrderHistoryModel : CustomerPageModel
    {
        private readonly IOrderService _orderService;
        public const int pageSize = 8;
        public OrderHistoryModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<Order> Order { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public OrderStatus CurrentOrderStatus {  get; set; }
        public IActionResult OnGet(int? pageNo, string? orderStatus)
        {
            if (false == Enum.TryParse<OrderStatus>(orderStatus, out var status))
            {
                CurrentOrderStatus = OrderStatus.Pending;
            } else
            {
                CurrentOrderStatus = status;
            }
            if (false == int.TryParse(HttpContext.Session.GetString("CustomerId"), out int userId))
            {
                return RedirectToPage("/Login");
            }
            var (orderList, pageCount) = _orderService.GetCustomerOrderByStatus(userId, CurrentOrderStatus, pageNo ?? 1, pageSize);
            Order = orderList;
            CurrentPage = pageNo ?? 1;
            TotalPage = pageCount;
            return Page();
        }
    }
}
