using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using ITHelpDesk.Categories;

namespace ITHelpDesk.Categories
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryAppService(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetListAsync()
        {
            var categories = await _categoryRepository.GetListAsync();
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var category = ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input);
            await _categoryRepository.InsertAsync(category);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public Task AssignAsync(Guid ticketId, Guid assigneeId)
        {
            throw new NotImplementedException();
        }

        public Task ResolveAsync(Guid ticketId)
        {
            throw new NotImplementedException();
        }

        public Task CloseAsync(Guid ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
