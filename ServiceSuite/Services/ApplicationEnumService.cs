using Microsoft.EntityFrameworkCore;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Interfaces;
using ServiceSuite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class ApplicationEnumService : IApplicationEnumService
    {
        private readonly MainContext _context;

        public ApplicationEnumService(MainContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationEnumDto>> GetAsync()
        {
            return await _context.ApplicationEnums
                    .Select(x => new ApplicationEnumDto()
                    {
                        ApplicationEnumId = x.ApplicationEnumId,
                        Category = x.Category,
                        Name = x.Name,
                        SubCategory = x.SubCategory,
                        Value = x.Value,
                        ValueType = x.ValueType
                    })
                    .ToListAsync();
        }
    }
}
