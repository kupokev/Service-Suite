using ServiceSuite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSuite.Interfaces
{
    public interface IEnumService
    {
        Task<IEnumerable<ApplicationEnumDto>> GetAsync(string category, string subcategory);

        Task<bool> RefreshAsync();
    }
}
