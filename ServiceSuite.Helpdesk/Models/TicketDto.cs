using System;

namespace ServiceSuite.Helpdesk.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }

        public int PriorityId { get; set; }

        public string Priority { get; set; }

        public int StatusId { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Assignee { get; set; }

        public int AssigneeId { get; set; }

        public string CreatedBy { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnDisplay
        {
            get
            {
                return CreatedOn.ToString("yyyy-MM-dd");
            }
        }
    }
}
