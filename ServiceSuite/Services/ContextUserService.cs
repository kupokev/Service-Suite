using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Interfaces;
using ServiceSuite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class ContextUserService : IContextUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MainContext _context;

        public ContextUserService(IHttpContextAccessor contextAccessor, MainContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<UserDto> GetCurrentUser()
        {
            return await GetUserByName(_contextAccessor.HttpContext.User.Identity.Name);
        }

        public async Task<UserDto> GetUserByName(string name)
        {
            return await _context.Users.Where(x => x.UserName == name)
                    .Select(x => new UserDto()
                    {
                        UserId = x.Id,
                        Username = x.UserName
                    }).FirstOrDefaultAsync();
        }
    }
}
