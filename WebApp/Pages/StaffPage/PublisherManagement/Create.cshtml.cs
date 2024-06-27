using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using DataAccessObjects;
using BusinessObjects.DTO;
using AutoMapper;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.PublisherManagement
{
    public class CreateModel : StaffPageModel
    {
        private readonly IPublisherService _service;
        private readonly IMapper _mapper;

        public CreateModel(IPublisherService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PublisherDTO Publisher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Add(_mapper.Map<Publisher>(Publisher));

            return RedirectToPage("./Index");
        }
    }
}
