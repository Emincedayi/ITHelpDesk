using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ITHelpDesk.Tickets
{
    public class TicketAppService : ApplicationService, ITicketAppService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketAppService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

          public async Task<TicketDto> CreateAsync(
              string Title,
              string Description,
              TicketPriority Priority,
              TicketStatus Status ,
              Guid CategoryId
               )
           {
               var ticket = new Ticket(Guid.NewGuid(), Title, Description, Priority,CategoryId, Status);
               await _ticketRepository.InsertAsync(ticket);
               return ObjectMapper.Map<Ticket, TicketDto>(ticket);
           } 

      



        public async Task<TicketDto> GetAsync(Guid id)
        {
            var ticket = await _ticketRepository.GetWithCommentsAsync(id);
            return ObjectMapper.Map<Ticket, TicketDto>(ticket);
        }

      /*  public async Task AssignAsync(Guid ticketId, Guid assigneeId)
        {
            var ticket = await _ticketRepository.GetAsync(ticketId);
            ticket.Assign(assigneeId);
        }

        public async Task ResolveAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetAsync(ticketId);
            ticket.Resolve();
        }

        public async Task CloseAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetAsync(ticketId);
            ticket.Close();*/
        }
    }



