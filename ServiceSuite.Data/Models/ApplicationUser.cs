using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ServiceSuite.Data.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }

        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<ApplicationUserTeam> ApplicationUserTeams { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}
