﻿using Microsoft.EntityFrameworkCore;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Interfaces;
using ServiceSuite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Services
{
    public class EnumService : IEnumService
    {
        private List<ApplicationEnumDto> _enums { get; set; }

        public EnumService()
        {
            // Generate list when app is launched
            RefreshAsync().GetAwaiter().GetResult();
        }

        public Task<IEnumerable<ApplicationEnumDto>> GetAsync(string category, string subcategory)
        {
            Task<IEnumerable<ApplicationEnumDto>> task = Task<IEnumerable<ApplicationEnumDto>>.Factory.StartNew(() =>
            {
                return _enums.Where(x => x.Category.ToLower() == category.Trim().ToLower() && x.SubCategory.ToLower() == subcategory.Trim().ToLower()).OrderBy(x => x.Name).ToList();
            });

            return task;
        }

        public async Task<bool> RefreshAsync()
        {
            try
            {
                _enums = (await GetAsync()).ToList();

                _enums.AddRange(await GenerateEnumsAsync());

                return true;
            }
            catch
            {
                return false;
            }

        }

        private Task<IEnumerable<ApplicationEnumDto>> GenerateEnumsAsync()
        {
            Task<IEnumerable<ApplicationEnumDto>> task = Task<IEnumerable<ApplicationEnumDto>>.Factory.StartNew(() =>
            {
                var result = new List<ApplicationEnumDto>();

                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1000, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Lowest", Value = "0", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1001, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Low", Value = "1", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1002, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Medium", Value = "2", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1003, Category = "helpdesk", SubCategory = "ticketpriority", Name = "High", Value = "3", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1004, Category = "helpdesk", SubCategory = "ticketpriority", Name = "Highest", Value = "4", ValueType = "int" });

                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1010, Category = "helpdesk", SubCategory = "ticketstatus", Name = "New", Value = "0", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1011, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Assigned", Value = "1", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1012, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Closed", Value = "2", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1013, Category = "helpdesk", SubCategory = "ticketstatus", Name = "Resolved", Value = "3", ValueType = "int" });

                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1020, Category = "helpdesk", SubCategory = "ticketnotetype", Name = "Internal", Value = "0", ValueType = "int" });
                result.Add(new ApplicationEnumDto() { ApplicationEnumId = 1021, Category = "helpdesk", SubCategory = "ticketnotetype", Name = "Public", Value = "1", ValueType = "int" });

                return result;
            });

            return task;
        }

        private async Task<IEnumerable<ApplicationEnumDto>> GetAsync()
        {
            using (var context = new MainContextFactory().CreateDbContext())
            {
                return await context.ApplicationEnums
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
}