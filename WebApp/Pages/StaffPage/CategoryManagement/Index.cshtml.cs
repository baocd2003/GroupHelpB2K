using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using BusinessObjects.DTO;
using WebApp.Helpers;
using Services.Interface;
using WebApp.BaseModelPage;

namespace WebApp.Pages.StaffPage.CategoryManagement
{
    public class IndexModel : StaffPageModel
    {
        private readonly ICategoryService _service;
        private readonly IConfiguration Configuration;

        public IndexModel(ICategoryService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }

        public List<Category> CategoryList { get;set; } = default!;

        public void OnGet(int? pageIndex)
        {
            var pageSize = Configuration.GetValue("PageSize", 4);
            IQueryable<Category> categoryIQs = _service.GetAll().AsQueryable();
            CategoryList = _service.GetAll();
        }
    }
}
