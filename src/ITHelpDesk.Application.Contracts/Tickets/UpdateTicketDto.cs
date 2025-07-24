using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpDesk.Tickets
{
    public class UpdateTicketDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public TicketPriority Priority { get; set; }
       // public TicketStatus Status { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
