using Microsoft.AspNetCore.Identity;

namespace ServicePortal.Data.Models.Entity
{
    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
