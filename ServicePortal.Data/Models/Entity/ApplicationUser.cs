using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ServicePortal.Data.Models.Entity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }

        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
