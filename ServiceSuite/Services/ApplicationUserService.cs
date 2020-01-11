using Microsoft.AspNetCore.Identity;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Data.Models;
using ServiceSuite.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            GenerateDefaultUser().GetAwaiter().GetResult();
        }

        public async Task InitializeUsers()
        {
            using (var context = new MainContextFactory().CreateDbContext())
            {
                var userCount = context.Users.Select(x => 1).Count();

                if (userCount == 0)
                {
                    await GenerateDefaultUser();
                }
            }
        }

        private async Task GenerateDefaultUser()
        {
            // Create Role
            var role = new ApplicationRole()
            {
                Name = "System Administrator"
            };

            var createdRole = await _roleManager.CreateAsync(role);

            // Create User
            var user = new ApplicationUser()
            {
                UserName = "Administrator"
            };

            var createdUser = await _userManager.CreateAsync(user, "Password123!");

            // Add User to Role
            await _userManager.AddToRoleAsync(user, "System Administrator");
        }
    }
}