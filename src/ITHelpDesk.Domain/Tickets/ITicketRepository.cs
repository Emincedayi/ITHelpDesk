using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ITHelpDesk.Tickets
{
    public interface ITicketRepository : IRepository<Ticket, Guid>
    {
        Task<Ticket> GetWithCommentsAsync(Guid id);
        Task<Ticket> ChangeStatus(Guid id, TicketStatus status);
        Task<Ticket> ResolveAsync(Guid ticketId);
        Task<List<Ticket>> GetListAsync(int skipCount, int maxResultCount, string sorting);
       
        Task<int> GetCountAsync();

    }
}
