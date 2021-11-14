using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood.Data 
{
    public class SQLServerDbContext : DataContext
    {
        public SQLServerDbContext(IConfiguration configuration) : base(configuration)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to SQLServer database
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

    }
}