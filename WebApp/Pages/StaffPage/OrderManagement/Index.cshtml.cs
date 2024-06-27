using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using WebApp.Helpers;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interface;
using System.Drawing.Printing;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.OrderManagement
{
    public class IndexModel : StaffPageModel
    {
        private readonly IOrderService _service;
        private readonly IConfiguration Configuration;

        public IndexModel(IOrderService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }

        public List<Order> OrderList { get; set; } = default!;
        public List<SelectListItem> OrderStatusOptions { get; set; }
        [BindProperty]
        public OrderStatus SelectedStatus { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 8;
        public int TotalPage { get; set; }
        public void OnGet(int? pageIndex, string? selectedStatus)
        {
            OrderStatusOptions = Enum.GetValues(typeof(OrderStatus))
                                      .Cast<OrderStatus>()
                                      .Select((x, index) => new SelectListItem
                                      {
                                          Text = x.ToString(),
                                          Value = index.ToString(),
                                      })
                                      .ToList();
            var (orders, pageCount) = _service.GetAll(CurrentPage,ItemPerPage);
            OrderList = orders;
            CurrentPage = pageCount;
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                ViewData["SelectedStatus"] = selectedStatus;
                var pageSize = Configuration.GetValue("PageSize", 4);
                var (orderList, pageC) = _service.GetByStatus(Enum.Parse<OrderStatus>(selectedStatus, true), pageIndex ?? 1, pageSize);
                OrderList = orderList;
                CurrentPage = pageC;
            }
            else
            {
                ViewData["SelectedStatus"] = null;
            }
        }

        public IActionResult OnPostUpdateStatus(int orderId, OrderStatus selectedOrderStatus)
        {
            var existedOrder = _service.GetOrder(orderId);
            existedOrder.OrderStatus = selectedOrderStatus;
            _service.Update(existedOrder);
            return RedirectToPage("./Index");
        }
    }
}
