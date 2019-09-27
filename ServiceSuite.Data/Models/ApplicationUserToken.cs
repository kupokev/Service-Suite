using Microsoft.AspNetCore.Identity;

namespace ServiceSuite.Data.Models
{
    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
