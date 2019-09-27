using Microsoft.AspNetCore.Identity;

namespace ServiceSuite.Data.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
