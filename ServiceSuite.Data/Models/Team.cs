using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceSuite.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ICollection<ApplicationUserTeam> ApplicationUserTeams { get; set; }
    }
}
