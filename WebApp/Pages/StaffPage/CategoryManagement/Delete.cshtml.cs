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

namespace WebApp.Pages.StaffPage.CategoryManagement
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;

        public DeleteModel(ICategoryService service)
        {
            _service = service;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _service.GetById((int)id);

            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _service.GetById((int) id);

            if (category != null)
            {
                Category = category;
                _service.Delete(Category);
            }

            return RedirectToPage("./Index");
        }
    }
}
