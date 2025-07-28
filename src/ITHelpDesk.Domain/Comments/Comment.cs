using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ITHelpDesk.Comments
{
    public class Comment : FullAuditedEntity<Guid>
    {
        public Guid TicketId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }

        protected Comment() { }

        public Comment(Guid id, Guid ticketId, string text, Guid userId)
            : base(id)
        {
            TicketId = ticketId;
            Text = text;
            UserId = userId;
        }
    }
}
