using ITHelpDesk.Comments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ITHelpDesk.Tickets
{
 

    public class Ticket : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
      //  public DateTime LastUpdatedAt { get; set; } // Yeni eklendi
    //    public string UserEmail { get; set; }
     //    public DateTime ClosedDate { get;  set; }
        //  public Guid? AssigneeId { get;  set; }


        public Guid CategoryId { get; set; }

        public List<Comment> Comments { get; set; }

        protected Ticket() { }

        public Ticket(Guid id, string title, string description, 
            TicketPriority priority, Guid categoryId, 
            TicketStatus ticketStatus)
            : base(id)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = ticketStatus;
          CategoryId = categoryId;
            Comments = new List<Comment>();
        }


        /* public void Assign(Guid assigneeId)
         {
             AssigneeId = assigneeId;
         }

         public void Resolve()
         {
             Status = TicketStatus.Resolved;
         }

         public void Close()
         {
             Status = TicketStatus.Closed;
         }*/

        public void StartProgress()
        {
            if (Status != TicketStatus.Open)
            {
                throw new Exception("Only open tickets can be moved to In Progress.");
            }
            Status = TicketStatus.InProgress;
        }

        public void Resolve()
        {
            if (Status != TicketStatus.InProgress)
            {
                throw new Exception("Only in-progress tickets can be resolved.");
            }
            Status = TicketStatus.Resolved;
          
        }

        public void Close()
        {
            if (Status != TicketStatus.Resolved)
            {
                throw new Exception("ResolvedSecIdKısmını");
               
            }
            Status = TicketStatus.Closed;
          
        }

    }
}

