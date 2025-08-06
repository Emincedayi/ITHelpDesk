using ITHelpDesk.Tickets;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

using ITHelpDesk.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ITHelpDesk.Application.Tickets
{
    public class TicketStatusCheckerJob : AsyncBackgroundJob<object>, ITransientDependency
    {
        private readonly ITHelpDeskDbContext _dbContext;
        private readonly IEmailSender _emailSender;

        public TicketStatusCheckerJob(ITHelpDeskDbContext dbContext, IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _emailSender = emailSender;
        }

        public override async Task ExecuteAsync(object args)
        {
            var sixHoursAgo = DateTime.UtcNow.AddMinutes(-1);
            var tickets = await _dbContext.Tickets
                .Where(t => t.Status == TicketStatus.InProgress)
                .Where(t => t.LastModificationTime < sixHoursAgo || t.LastModificationTime == null)
                .ToListAsync();

            foreach (var ticket in tickets)
            {
                await _emailSender.SendAsync(
                    to: "memincedayi@gmail.com",
                    subject: $"Ticket #{ticket.Id} Güncelleme Hatırlatması",
                    body: $"Ticket '{ticket.Title}' (ID: {ticket.Id}) 1 saattir 'InProgress' statüsünde ve güncellenmedi. Lütfen ilgilenin."
                );
            }
        }
    }
}