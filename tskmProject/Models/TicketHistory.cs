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
    
    public partial class TicketHistory
    {
        public int TicketID { get; set; }
        public Nullable<int> OldAssigneeID { get; set; }
        public Nullable<int> NewAssigneeID { get; set; }
        public string Comment { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
    
        public virtual Ticket Ticket { get; set; }
        public virtual User OldAssignee { get; set; }
        public virtual User NewAssignee { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
