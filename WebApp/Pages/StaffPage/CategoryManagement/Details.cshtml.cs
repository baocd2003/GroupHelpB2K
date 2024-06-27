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
    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _service;

        public DetailsModel(ICategoryService service)
        {
            _service = service;
        }

      public Category Category { get; set; } = default!; 

        public IActionResult OnGet(int id)
        {
            var category = _service.GetById(id);
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
    }
}
