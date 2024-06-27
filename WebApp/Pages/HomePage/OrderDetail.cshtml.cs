using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.HomePage
{
    public class OrderDetailModel : CustomerPageModel
    {
        private readonly IOrderDetailService  _orderDetailService;
        private readonly IOrderService _orderService;
        public OrderDetailModel(IOrderDetailService detailService, IOrderService orderService)
        {
            _orderDetailService = detailService;
            _orderService = orderService;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order? order = _orderService.GetOrder((int)id);
            if (false == int.TryParse(HttpContext.Session.GetString("CustomerId"), out int userId))
            {
                return RedirectToPage("/Login");
            }
            if (order.UserId != userId)
            {
                return RedirectToPage("/Error");
            }
            OrderDetail = _orderDetailService.GetByOrderId(order.OrderId);
            return Page();
        }
    }
}
