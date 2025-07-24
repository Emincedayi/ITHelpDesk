
/*using ITHelpDesk.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ITHelpDesk.Tickets
{
    public class EFCoreTicketRepository : EfCoreRepository<ITHelpDeskDbContext, Ticket, Guid>, ITicketRepository
    {
        public EFCoreTicketRepository(IDbContextProvider<ITHelpDeskDbContext> dbContextProvider)
            : base(dbContextProvider) { }

        public async Task<Ticket> CreateAsync(string Title, string Description, TicketPriority Priority, TicketStatus Status, Guid? AssigneeId, Guid CategoryId)
        {
            var dbContext = await GetDbContextAsync(); 
            var ticket = new Ticket { Title = Title, Description = Description, 
                Priority = Priority, Status = Status, AssigneeId = AssigneeId, 
              //  CategoryId = CategoryId// };

            dbContext.Tickets.Add(ticket);
            await dbContext.SaveChangesAsync();
            return ticket;

          
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetListByPriorityAsync(TicketPriority priority)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetListByStatusAsync(TicketStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> UpdateAsync(Guid Id, string Title, string Description,
            TicketPriority Priority, TicketStatus Status, Guid? AssigneeId,
            Guid CategoryId) 

        {
            var dbContext = await GetDbContextAsync();
            var ticket = await dbContext.Tickets.FindAsync(Id);
            if (ticket == null)
            {
                throw new Exception($"Category with Id '{Id}' not found.");
            }

           // ticket.Id = Id;
            ticket.Description = Description;
            ticket.Title = Title;
            ticket.Priority = Priority;
            ticket.Status = Status;
            ticket.AssigneeId = AssigneeId;
           // ticket.CategoryId = CategoryId;

            dbContext.Tickets.Update(ticket);
            await dbContext.SaveChangesAsync();

            return ticket; 


         }
}
}

*/

using ITHelpDesk.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ITHelpDesk.Tickets
{
    public class EfCoreTicketRepository : EfCoreRepository<ITHelpDeskDbContext, Ticket, Guid>, ITicketRepository
    {
        public EfCoreTicketRepository(IDbContextProvider<ITHelpDeskDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task<Ticket> GetWithCommentsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}


