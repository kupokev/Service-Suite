using System;

namespace ServiceSuite.Data.Models
{
    public class ApplicationUserTeam
    {
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
