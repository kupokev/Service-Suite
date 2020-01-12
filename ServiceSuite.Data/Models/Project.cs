using System;
using System.Collections.Generic;

namespace ServiceSuite.Data.Models
{
    public class Project : BaseEntity
    {
        public int ProjectId { get; set; }

        public int? ParentProjectId { get; set; }

        public virtual Project ParentProject { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }


        public virtual ICollection<Project> ChildProjects { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
