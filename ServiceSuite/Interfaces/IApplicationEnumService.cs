using ServiceSuite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSuite.Interfaces
{
    public interface IApplicationEnumService
    {
        Task<IEnumerable<ApplicationEnumDto>> GetAsync();
    }
}
