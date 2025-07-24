using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ITHelpDesk.Tickets
{
    public interface ITicketRepository : IRepository<Ticket, Guid>
    {
        Task<Ticket> GetWithCommentsAsync(Guid id);
    }
}
