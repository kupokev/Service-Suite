using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceSuite.Data.Models
{
    public class TicketChangeLog
    {
        public Guid ChangeKey { get; set; }

        public int TicketId { get; set; }

        public int Priority { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? AssignedUserId { get; set; }

        public int CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string Note { get; set; }

        public int TicketNoteType { get; set; }

        public DateTime ChangeTime { get; set; }

        public int ChangeUserId { get; set; }
    }
}
