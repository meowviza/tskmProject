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
    
    public partial class Catagory
    {
        public Catagory()
        {
            this.Knowledgebase = new HashSet<Knowledgebase>();
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int catagoryID { get; set; }
        public string catagoryName { get; set; }
    
        public virtual ICollection<Knowledgebase> Knowledgebase { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
