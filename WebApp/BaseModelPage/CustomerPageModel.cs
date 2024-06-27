using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.BaseModelPage
{
    public class CustomerPageModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);
            if (context.HttpContext.Session.GetString("Role") != "Customer")
            {
                context.Result = RedirectToPage("/Error");
            }
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("CustomerId");
            return RedirectToPage("/Login");
        }
    }
}
