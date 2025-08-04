using AutoMapper.Internal.Mappers;
using ITHelpDesk.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace ITHelpDesk.Tickets
{
    public class EfCoreTicketRepository : EfCoreRepository<ITHelpDeskDbContext, Ticket, Guid>, ITicketRepository
    {
        /* public EfCoreTicketRepository(IDbContextProvider<ITHelpDeskDbContext> dbContextProvider)
             : base(dbContextProvider)
         {
         }*/
        private readonly IRepository<IdentityUser, Guid> _userRepository;

        public EfCoreTicketRepository(
            IDbContextProvider<ITHelpDeskDbContext> dbContextProvider,
            IRepository<IdentityUser, Guid> userRepository)
            : base(dbContextProvider)
        {
            _userRepository = userRepository;
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


     /*   public async Task<List<Ticket>> GetStaleTicketsAsync()
        {
            var threshold = DateTime.UtcNow.AddHours(-6);
            var query = await GetQueryableAsync();

            var tickets = await query
                .Where(t => t.Status == TicketStatus.InProgress && t.LastUpdatedAt != null && t.LastUpdatedAt <= threshold)
                .ToListAsync();*/

            // UserEmail'i IdentityUser'dan al (opsiyonel, UserId kullanıyorsanız)
          /*  foreach (var ticket in tickets)
            {
                if (ticket.UserId.HasValue)
                {
                    var user = await _userRepository.FindAsync(ticket.UserId.Value);
                    if (user != null)
                    {
                        ticket.UserEmail = user.Email;
                    }
                }
            }

            return tickets;
        }*/







    }
}



