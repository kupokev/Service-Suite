using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ServiceSuite.Data.Contexts
{
    public class MainContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MainContext>();

            string connectionString;

            if (Environment.MachineName.Equals("RKHDEV01", StringComparison.InvariantCultureIgnoreCase))
            {
                connectionString = configuration.GetConnectionString("Server=RKHSQL02;Database=ServicePortal;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            else
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            builder.UseSqlServer(connectionString);

            return new MainContext(builder.Options);
        }

        public MainContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }
    }
}