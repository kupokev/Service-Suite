using Microsoft.AspNetCore.Identity;

namespace ServiceSuite.Data.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
