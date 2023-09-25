using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");
        
        builder 
            .HasOne(u => u.PersonalTrainer)
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.PersonalTrainerId);
        
        builder
            .HasOne(u => u.Plan)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.PlanId);
    }
}