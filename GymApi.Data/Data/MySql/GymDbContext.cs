using GymApi.Data.Data.ConfigModel;
using GymApi.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data.Data.MySql
{
    public class GymDbContext : IdentityDbContext<User>
    {
        public GymDbContext(DbContextOptions options) : base (options) { }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TicketGate> TicketGates { get; set; }
        public DbSet<TrainingUser> UserTrainings { get; set; }
        public DbSet<ExerciseTraining> ExerciseTrainings { get; set; }
        public DbSet<TicketGateUser> TicketGateUsers { get; set; }
        public DbSet<PersonalByUser> PersonalByUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PersonalTrainerConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new TrainingConfig());
            modelBuilder.ApplyConfiguration(new ExerciseConfig());
            modelBuilder.ApplyConfiguration(new TrainingUserConfig());
            modelBuilder.ApplyConfiguration(new ExerciseTrainingConfig());
            modelBuilder.ApplyConfiguration(new TicketGateConfig());
            modelBuilder.ApplyConfiguration(new TicketGateUsersConfig());
            modelBuilder.ApplyConfiguration(new PersonalByUserConfig());

            modelBuilder.Entity<TicketGate>().HasData(
                new TicketGate { Id = Guid.NewGuid(), Name = "CatracaA"},
                new TicketGate { Id = Guid.NewGuid(), Name = "CatracaB"},
                new TicketGate { Id = Guid.NewGuid(), Name = "CatracaC"}
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
