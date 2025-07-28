using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpDesk.Tickets
{
    public class TicketManager : ITicketManager
    {
        public void CheckStatusRule(TicketStatus status)
        {
            if(status == TicketStatus.Closed)
            {
                throw new InvalidOperationException("Bu ticket durumu değiştirelemez"); 
         
            }
        }
    }
}
