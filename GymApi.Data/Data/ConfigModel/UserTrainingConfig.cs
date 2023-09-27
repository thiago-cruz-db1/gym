using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class UserTrainingConfig : IEntityTypeConfiguration<UserTraining>
{
    public void Configure(EntityTypeBuilder<UserTraining> builder)
    {
        builder
            .ToTable("User_training");
        
        builder
            .Property(a => a.TrainingObservations)
            .HasColumnName("training_observation")
            .HasColumnType("varchar(45)")
            .IsRequired();

        builder
            .HasKey(ut => new { ut.UserId, ut.TrainingId });

        builder
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTrainings)
            .HasForeignKey(ut => ut.UserId);
        
        builder
            .HasOne(ut => ut.Training)
            .WithMany(t => t.UserTrainings)
            .HasForeignKey(ut => ut.TrainingId);
    }
}