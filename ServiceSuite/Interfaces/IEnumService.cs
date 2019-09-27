using ServiceSuite.Models;
using System.Collections.Generic;

namespace ServiceSuite.Interfaces
{
    public interface IEnumService
    {
        IEnumerable<ApplicationEnumDto> Get(string category, string subcategory);

        bool Refresh();
    }
}
