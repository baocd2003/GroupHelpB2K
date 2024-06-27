using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using BusinessObjects.DTO;
using AutoMapper;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.CategoryManagement
{
    public class EditModel : StaffPageModel
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public EditModel(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [BindProperty]
        public CategoryDTO Category { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            Category = _mapper.Map<CategoryDTO>(category);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.Update(_mapper.Map<Category>(Category));
            return RedirectToPage("./Index");
        }
    }
}
