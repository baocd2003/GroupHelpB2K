using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using WebApp.Helpers;
using System.Configuration;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.PublisherManagement
{
    public class IndexModel : StaffPageModel
    {
        private readonly IPublisherService _service;
        private readonly IConfiguration Configuration;

        public IndexModel(IPublisherService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }

        public List<Publisher> PublisherList { get;set; } = default!;

        public void OnGetAsync(int? pageIndex)
        {
            var pageSize = Configuration.GetValue("PageSize", 4);
            IQueryable<Publisher> publisherIQs = _service.GetAll().AsQueryable();
            PublisherList = _service.GetAll();
        }
    }
}
