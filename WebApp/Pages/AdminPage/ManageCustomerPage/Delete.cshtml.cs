using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using WebApp.BaseModelPage;
using Services.Interface;

namespace WebApp.Pages.AdminPage.ManageCustomerPage
{
    public class DeleteModel : AdminPageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User? user = _userService.Get((int)id);

            if (user == null)
            {
                return NotFound();
            }

            User = user;

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User? user = _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }
            user.AccountStatus = AccountStatus.InActive;

            _userService.Update(user);

            return RedirectToPage("./Index");
        }
    }
}
