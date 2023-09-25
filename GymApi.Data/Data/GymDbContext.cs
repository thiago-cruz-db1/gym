using GymApi.Data.Data.ConfigModel;
using GymApi.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data.Data
{
    public class GymDbContext : IdentityDbContext<User>
    {
        public GymDbContext(DbContextOptions options) : base (options) { }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PersonalTrainerConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
