using Microsoft.AspNetCore.Identity;

namespace ServicePortal.Data.Models.Entity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
