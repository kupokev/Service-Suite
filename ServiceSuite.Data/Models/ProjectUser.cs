namespace ServiceSuite.Data.Models
{
    public class ProjectUser
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
