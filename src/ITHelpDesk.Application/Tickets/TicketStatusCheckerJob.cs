using ITHelpDesk.EntityFrameworkCore;
using ITHelpDesk.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
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
                await TestSmtpConnectionAsync(to: "memincedayi@gmail.com",
                      subject: $"Ticket #{ticket.Id} Güncelleme Hatırlatması",
                      body: $"Ticket '{ticket.Title}' (ID: {ticket.Id}) 1 saattir 'InProgress' statüsünde ve güncellenmedi. Lütfen ilgilenin.");
            }
        }

        public async Task TestSmtpConnectionAsync(string to, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("memincedayi@gmail.com", "nomvzbikriufpsim")
                };
                var message = new MailMessage
                {
                    From = new MailAddress("memincedayi@gmail.com", "HelpDesk"),
                    Subject = subject,
                    Body =body
                };
                message.To.Add(to);
                await client.SendMailAsync(message);
                Console.WriteLine("SMTP Test: Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SMTP Test Error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }
}