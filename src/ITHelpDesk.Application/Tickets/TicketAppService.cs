using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
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
            TicketStatus Status,
            Guid CategoryId
             )
        {
            var ticket = new Ticket(Guid.NewGuid(), Title, Description, Priority, CategoryId, Status);
            await _ticketRepository.InsertAsync(ticket);
            return ObjectMapper.Map<Ticket, TicketDto>(ticket);
        }

        public async Task<PagedResultDto<TicketDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var tickets = await _ticketRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting ?? "CreationTime DESC"
            );

            var totalCount = await _ticketRepository.GetCountAsync();

            return new PagedResultDto<TicketDto>(
                totalCount,
                ObjectMapper.Map<List<Ticket>, List<TicketDto>>(tickets)
            );
        }





        public async Task<TicketDto> GetAsync(Guid id)
        {
            var ticket = await _ticketRepository.GetWithCommentsAsync(id);
            return ObjectMapper.Map<Ticket, TicketDto>(ticket);
        }

        /*   public async Task AssignAsync(Guid ticketId, Guid assigneeId)
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
               ticket.Close();
           }*/

      
        public async Task StartProgressAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetAsync(ticketId);

            ticket.StartProgress();

            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task<TicketDto> ResolveAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.ResolveAsync(ticketId);

            return ObjectMapper.Map<Ticket, TicketDto>(ticket);
        }


      

        public async Task<TicketDto> CloseAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetAsync(ticketId);

            ticket.Close(); 
            await _ticketRepository.UpdateAsync(ticket);

            return ObjectMapper.Map<Ticket, TicketDto>(ticket);
        }

     
    }
}



