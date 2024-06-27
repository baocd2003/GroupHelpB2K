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

namespace WebApp.Pages.StaffPage.PublisherManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IPublisherService _service;

        public DeleteModel(IPublisherService service)
        {
            _service = service;
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _service.GetById((int) id);

            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var publisher = _service.GetById((int)id);

            if (publisher != null)
            {
                Publisher = publisher;
                _service.Delete(Publisher);
            }

            return RedirectToPage("./Index");
        }
    }
}
