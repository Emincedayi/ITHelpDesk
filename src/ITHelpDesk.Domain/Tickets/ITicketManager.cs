using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ITHelpDesk.Tickets
{
    public interface ITicketManager
    {
        void CheckStatusRule(TicketStatus status);
        
    }
}
