//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tskmProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public Ticket()
        {
            this.TicketReply = new HashSet<TicketReply>();
            this.Files = new HashSet<File>();
            this.TicketHistories = new HashSet<TicketHistory>();
        }
    
        public int ticketID { get; set; }
        public string ticketTitle { get; set; }
        public string ticketDetail { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int catagoryID { get; set; }
        public int statusID { get; set; }
        public int userID { get; set; }
        public string Place { get; set; }
        public string Tel { get; set; }
        public Nullable<int> AssigneeID { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    
        public virtual Catagory Catagory { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<TicketReply> TicketReply { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual User Assignee { get; set; }
    }
}
