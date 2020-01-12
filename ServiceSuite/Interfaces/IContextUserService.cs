using ServiceSuite.Models;
using System.Threading.Tasks;

namespace ServiceSuite.Interfaces
{
    public interface IContextUserService
    {
        Task<UserDto> GetCurrentUser();

        Task<UserDto> GetUserByName(string name);
    }
}
