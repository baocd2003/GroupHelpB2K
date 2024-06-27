using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using WebApp.BaseModelPage;
using Services.Interface;

namespace WebApp.Pages.AdminPage.ManageStaffPage
{
    public class CreateModel : AdminPageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        { 
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || User == null)
            {
                return Page();
            }
            User user = new()
            {
                Email = User.Email,
                Password = User.Password,
                UserName = User.UserName,
                AccountStatus = AccountStatus.Active,
                Role = UserRole.Staff,
            };

            _userService.Add(user);

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        public string? UserName { get; set; }

    }
}
