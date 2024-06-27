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

namespace WebApp.Pages.StaffPage.PublisherManagement
{
    public class EditModel : PageModel
    {
        private readonly IPublisherService _service;
        private readonly IMapper _mapper;

        public EditModel(IPublisherService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [BindProperty]
        public PublisherDTO Publisher { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _service.GetById((int)id);
            if (publisher == null)
            {
                return NotFound();
            }
            Publisher = _mapper.Map<PublisherDTO>(publisher);
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

            _service.Update(_mapper.Map<Publisher>(Publisher));
            return RedirectToPage("./Index");
        }
    }
}
