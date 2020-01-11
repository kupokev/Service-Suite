using System;

namespace ServiceSuite.Data.Models
{
    public class Ticket : BaseEntity
    {
        public int TicketId { get; set; }

        public int Priority { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? AssignedUserId { get; set; }
        
        public DateTime? DueDate { get; set; }
    }
}
