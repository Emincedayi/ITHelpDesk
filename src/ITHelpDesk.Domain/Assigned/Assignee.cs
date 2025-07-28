using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ITHelpDesk.Assigned
{
    public class Assignee : Entity<Guid>
    { 
        public string Name { get; set; } 
        public Assignee() { }   
    }
}
