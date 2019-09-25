using Microsoft.AspNetCore.Identity;

namespace ServicePortal.Data.Models.Entity
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
