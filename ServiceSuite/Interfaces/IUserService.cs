using ServiceSuite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSuite.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetActiveUsers();

        Task<IEnumerable<UserDto>> GetUsers();
    }
}
