using Microsoft.AspNetCore.Identity;

namespace ServicePortal.Data.Models.Entity
{
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
