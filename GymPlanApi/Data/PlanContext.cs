using GymPlanApi.Data.ConfigModel;
using GymPlanApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GymPlanApi.Data
{
    public class PlanContext : DbContext
    {
        public PlanContext(DbContextOptions<PlanContext> options) : base(options) { }

        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfig());
        }
    }
}
