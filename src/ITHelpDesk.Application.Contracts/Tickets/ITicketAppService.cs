using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ITHelpDesk.Tickets
{
    public interface ITicketAppService : IApplicationService
    {
        Task<TicketDto> CreateAsync(string Title,
              string Description,
              TicketPriority Priority,
              TicketStatus Status,
              Guid CategoryId);
     
        Task<TicketDto> GetAsync(Guid id);
        //  Task AssignAsync(Guid ticketId, Guid assigneeId); 
        Task<PagedResultDto<TicketDto>> GetListAsync(PagedAndSortedResultRequestDto input);


        Task<TicketDto> ResolveAsync(Guid ticketId);

        Task <TicketDto>CloseAsync(Guid ticketId);
    }
}

