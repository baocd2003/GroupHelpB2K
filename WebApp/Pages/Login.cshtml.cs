using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            var user = _userService.Login(Email, Password);
            if (user == null)
            {
                TempData["message"] = "Email or Password is not correct!";
                return Page();
            }
            else if (user.Role == LoginUserRole.Admin)
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToPage("/AdminPage/AdminHomePage");
            }
            else if (user.Role == LoginUserRole.Customer)
            {
                HttpContext.Session.SetString("Role", "Customer");
                HttpContext.Session.SetString("CustomerId", user.User.UserId.ToString());
                return RedirectToPage("/HomePage/Index"); ;
            }
            else if (user.Role == LoginUserRole.Staff)
            {
                HttpContext.Session.SetString("Role", "Staff");
                return RedirectToPage("StaffPage/BookManagement/Index");
            }

            return Page();
        }
    }
}
