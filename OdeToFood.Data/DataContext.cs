using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;

namespace OdeToFood.Data 
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to PostgreSQL database
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
       
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}