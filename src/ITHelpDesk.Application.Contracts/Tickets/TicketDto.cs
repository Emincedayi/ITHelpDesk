using System;
using System.Collections.Generic;

namespace ITHelpDesk.Tickets
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public Guid AssigneeId { get; set; }
        public Guid CategoryId { get; set; }
        public List<CommentDto> Comments { get; set; }
    }

    public class CreateUpdateTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriority Priority { get; set; } 
        public TicketStatus TicketStatus { get; set; }
        public Guid CategoryId { get; set; }
       //public Guid? AssigneeId { get; set; }
    }

    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
