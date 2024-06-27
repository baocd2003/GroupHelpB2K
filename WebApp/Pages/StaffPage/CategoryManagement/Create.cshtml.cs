using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.CategoryManagement
{
    public class CreateModel : StaffPageModel
    {
        private readonly ICategoryService _service;

        public CreateModel(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _service.Add(Category);
            }

            return RedirectToPage("./Index");
        }
    }
}
