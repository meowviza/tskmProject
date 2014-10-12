using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tskmProject.Models
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public TicketReply TicketReply { get; set; }
    }
}