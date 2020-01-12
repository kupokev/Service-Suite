using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServiceSuite.Data.Models;

namespace ServiceSuite.Data.Extensions
{
    // This solution was derived from https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization
    // There was a small adjustment to make it work with this version of EF
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                // EF Core won't allow us to set table name of entities that are not base entities
                if (entity.BaseType == null || entity.BaseType.GetType() == typeof(BaseEntity))
                {
                    entity.SetTableName(entity.DisplayName());
                }
            }
        }
    }
}
