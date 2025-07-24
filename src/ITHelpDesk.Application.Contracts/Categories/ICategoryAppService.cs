using ITHelpDesk.Categories;
using ITHelpDesk.Tickets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ITHelpDesk.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
           Task<List<CategoryDto>> GetListAsync();
           Task<CategoryDto> GetAsync(Guid id);
           Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);
           
    
       
        Task AssignAsync(Guid ticketId, Guid assigneeId);
        Task ResolveAsync(Guid ticketId);
        Task CloseAsync(Guid ticketId);
    }
}
