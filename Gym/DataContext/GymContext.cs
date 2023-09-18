using Gym.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gym.DataContext
{
    public class GymContext : DbContext
    {

        public DbSet<GymStoreProduct> Products { get; set; }

        public GymContext(DbContextOptions<GymContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
