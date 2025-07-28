using AutoMapper.Internal.Mappers;
using ITHelpDesk.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

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

        public async Task<Ticket> ChangeStatus(Guid id, TicketStatus status)
        {
            var ticket = await GetAsync(id);
            

            ticket.Status = status;
            
            return ticket;
        }
        public async Task<Ticket> ResolveAsync(Guid ticketId)
        {
            var ticket = await GetAsync(ticketId);

            ticket.Resolve();

            await UpdateAsync(ticket);

            return ticket;
        }

        public async Task<Ticket> GetWithCommentsAsync(Guid id)
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Tickets
                .Include(t => t.Comments) 
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public  async Task<List<Ticket>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var query = await GetQueryableAsync();

            // Sıralama, atlama ve alma işlemleri uygulanıyor
            query = (System.Linq.IQueryable<Ticket>)query.OrderBy(sorting ?? "CreationTime DESC")
                         .Skip(skipCount)
                         .Take(maxResultCount);

            // Manuel olarak listeye ekleniyor
            var result = new List<Ticket>();

            await foreach (var item in query.AsAsyncEnumerable())
            {
                result.Add(item);
            }

            return result;
        }


        public  async Task<int> GetCountAsync()
        {
            var query = await GetQueryableAsync();
            return await query.CountAsync();
        }

    }
}



