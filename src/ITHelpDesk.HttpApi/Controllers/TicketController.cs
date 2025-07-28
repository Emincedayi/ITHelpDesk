using Asp.Versioning;
using ITHelpDesk.Tickets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace ITHelpDesk.Controllers
{
    [Area("helpdesk")]
    [ControllerName("HelpDesk")]
    [Route("api/helpdesk/tickets")]
    public class TicketController : AbpController
    {
        private readonly ITicketAppService _ticketAppService;

        public TicketController(ITicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
        }

       
        [HttpPost]
        public Task<TicketDto> CreateAsync(/*CreateUpdateTicketDto input*/
                string Title,
         string Description,
        TicketPriority Priority,
          TicketStatus Status,

         Guid CategoryId
             )
         {
             return _ticketAppService.CreateAsync( Title,
          Description,
         Priority,
           Status,

          CategoryId);
         }


        [HttpGet("{id}")]
        public Task<TicketDto> GetAsync(Guid id)
            => _ticketAppService.GetAsync(id);



        [HttpPut("{id}/resolve")]
        public Task<TicketDto> ResolveAsync(Guid id) => _ticketAppService.ResolveAsync(id);


        [HttpPost("{id}/close")]
        public Task<TicketDto> CloseAsync(Guid id)
            => _ticketAppService.CloseAsync(id);
    }
}
