using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using WebApp.BaseModelPage;
using Services.Interface;

namespace WebApp.Pages.AdminPage.ManageCustomerPage
{
    public class IndexModel : AdminPageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; } = 8;
        public int TotalCount { get; set; }
        public IList<User> User { get;set; } = default!;

        public IActionResult OnGet()
        {
            var(users, pageCount) = _userService.GetByRole(UserRole.Customer,CurrentPage,ItemPerPage);
            User = users;
            TotalCount = pageCount;
            return Page();
        }
    }
}
