using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ServiceSuite.Data.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
