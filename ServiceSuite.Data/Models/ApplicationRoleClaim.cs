using Microsoft.AspNetCore.Identity;

namespace ServiceSuite.Data.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
