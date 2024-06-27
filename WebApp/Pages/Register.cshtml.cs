using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Services.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        public readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostRegister()
        {
            if (ModelState.IsValid)
            {
                bool error = false;
                bool check = _userService.IsEmailExisted(Input.Email);
                if (check)
                {
                    error = true;
                    ModelState.AddModelError("Input.Email", "This email is already registered.");
                }
                if (Input.Password.Equals(Input.ConfirmPassword) == false)
                {
                    error = true;
                    ModelState.AddModelError("Input.ConfirmPassword", "Confirm password is not correct.");
                }
                if (error)
                {
                    return Page();
                }
                else
                {
                    User user = new()
                    {
                        Email = Input.Email,
                        Password = Input.Password,
                        UserName = Input.CustomerFullName,
                        AccountStatus = AccountStatus.Active,
                        Role = UserRole.Customer,
                    };

                    _userService.Add(user);

                    return RedirectToPage("/Login");
                }
            }
            return Page();
        }
    }
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your confirm password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter your fullname.")]
        public string CustomerFullName { get; set; }
    }
}
