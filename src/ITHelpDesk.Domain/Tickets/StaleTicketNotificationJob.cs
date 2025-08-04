using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ITHelpDesk.Tickets
{
    public class StaleTicketNotificationJob : ITransientDependency
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<StaleTicketNotificationJob> _logger;

        public StaleTicketNotificationJob(
            ITicketRepository ticketRepository,
            IEmailSender emailSender,
            ILogger<StaleTicketNotificationJob> logger)
        {
            _ticketRepository = ticketRepository;
            _emailSender = emailSender;
            _logger = logger;
        }

        /*  public async Task ExecuteAsync()
          {
              try
              {
                  var staleTickets = await _ticketRepository.GetStaleTicketsAsync();
                  foreach (var ticket in staleTickets)
                  {
                      if (string.IsNullOrEmpty(ticket.UserEmail))
                      {
                          _logger.LogWarning($"Ticket #{ticket.Id} için e-posta adresi bulunamadı.");
                          continue;
                      }

                      await _emailSender.SendAsync(
                          to: ticket.UserEmail,
                          subject: $"Ticket #{ticket.Id} Güncelleme Uyarısı",
                          body: $"Merhaba,\n\nTicket #{ticket.Id} 6 saattir güncellenmedi ve hala 'InProgress' durumunda. " +
                                $"Lütfen durumu kontrol edin.\n\nSaygılar,\nTicketHelpDesk Ekibi",
                          isBodyHtml: false
                      );
                      _logger.LogInformation($"E-posta gönderildi: Ticket #{ticket.Id} -> {ticket.UserEmail}");
                  }
              }
              catch (Exception ex)
              {
                  _logger.LogError($"StaleTicketNotificationJob hatası: {ex.Message}");
              }
          }
      }*/
    }
}