using ServiceSuite.Data.Contexts;
using ServiceSuite.Interfaces;
using ServiceSuite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class UserService : IUserService
    {
        private List<UserDto> _users;

        public UserService()
        {
            InitializeUsers();
            RefreshUsers();
        }

        /// <summary>
        /// Retrives all active users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> GetActiveUsers() => await Task.FromResult(_users.Where(x => x.IsActive).ToList());

        /// <summary>
        /// Retrieves all active and non-active users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> GetUsers() => await Task.FromResult(_users.ToList());

        private void InitializeUsers()
        {
            using (var context = new MainContextFactory().CreateDbContext())
            {
                var defaultAdmin = context.Users.FirstOrDefault(x => x.Id == 1);

                // TODO: Figure out how to create a default user using the ApplicationUserService
            }
        }

        private void RefreshUsers()
        {
            using (var context = new MainContextFactory().CreateDbContext())
            {
                _users = context.Users
                    .Select(x => new UserDto()
                    {
                        UserId = x.Id,
                        Username = x.UserName
                    })
                    .ToList();
            }
        }
    }
}
