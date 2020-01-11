using ServiceSuite.Data.Contexts;
using ServiceSuite.Interfaces;
using ServiceSuite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceSuite.Services
{
    public class EnumService : IEnumService
    {
        private List<ApplicationEnumDto> _enums { get; set; }

        public EnumService()
        {
            // Generate list when app is launched
            Refresh();
        }

        public IEnumerable<ApplicationEnumDto> Get(string category, string subcategory)
        {
            return _enums.Where(x => x.Category.ToLower() == category.Trim().ToLower() && x.SubCategory.ToLower() == subcategory.Trim().ToLower()).OrderBy(x => x.Name);
        }

        public bool Refresh()
        {
            try
            {
                using (var context = new MainContextFactory().CreateDbContext())
                {
                    _enums = context.ApplicationEnums
                        .Select(x => new ApplicationEnumDto()
                        {
                            ApplicationEnumId = x.ApplicationEnumId,
                            Category = x.Category,
                            Name = x.Name,
                            SubCategory = x.SubCategory,
                            Value = x.Value,
                            ValueType = x.ValueType
                        })
                        .ToList();

                    _enums.AddRange(GenerateEnums());
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        private IEnumerable<ApplicationEnumDto> GenerateEnums()
        {
            var enums = new List<ApplicationEnumDto>();

            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1000, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Lowest", Value = "0", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1001, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Low", Value = "1", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1002, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Medium", Value = "2", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1003, Category = "helpdesk", SubCategory = "ticketpriority", Name = "High", Value = "3", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1004, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Highest", Value = "4", ValueType = "int" });

            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1010, Category = "helpdesk", SubCategory = "ticketstatus", Name = "New", Value = "0", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1011, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Assigned", Value = "1", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1012, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Closed", Value = "2", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1013, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Resolved", Value = "3", ValueType = "int" });

            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1020, Category = "helpdesk", SubCategory = "ticketnotetype", Name = "Internal", Value = "0", ValueType = "int" });
            enums.Add(new ApplicationEnumDto() { ApplicationEnumId = 1021, Category = "helpdesk", SubCategory = "ticketnotetype", Name = "Public", Value = "1", ValueType = "int" });

            return enums;
        }
    }
}