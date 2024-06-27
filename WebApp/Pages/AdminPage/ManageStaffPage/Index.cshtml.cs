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

namespace WebApp.Pages.AdminPage.ManageStaffPage
{
    public class IndexModel : AdminPageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IList<User> User { get;set; } = default!;
        [BindProperty]
        public int CurrentPage {  get; set; }
        [BindProperty]
        public int TotalPage {  get; set; }
        [BindProperty]
        public int ItemPerPage { get; set; } = 8;

        public IActionResult OnGet()
        {
            var (users, pageCount) = _userService.GetByRole(UserRole.Staff,CurrentPage,ItemPerPage);

            User = users;
            TotalPage = pageCount;
            return Page();
        }
    }
}
