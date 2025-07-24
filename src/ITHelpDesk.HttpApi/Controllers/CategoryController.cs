using Asp.Versioning;
using ITHelpDesk.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace ITHelpDesk.Controllers
{
    [Area("helpdesk")]
    [ControllerName("Category")]
    [Route("api/helpdesk/categories")]
    public class CategoryController : AbpController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // POST api/helpdesk/categories
        [HttpPost]
        public Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            return _categoryAppService.CreateAsync(input);
        }

        // GET api/helpdesk/categories/{id}
        [HttpGet("{id}")]
        public Task<CategoryDto> GetAsync(Guid id)
        {
            return _categoryAppService.GetAsync(id);
        }

        // GET api/helpdesk/categories
        [HttpGet]
        public Task<List<CategoryDto>> GetListAsync()
        {
            return _categoryAppService.GetListAsync();
        }
    }
}
