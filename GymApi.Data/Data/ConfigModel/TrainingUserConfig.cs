using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class TrainingUserConfig : IEntityTypeConfiguration<TrainingUser>
{
    public void Configure(EntityTypeBuilder<TrainingUser> builder)
    {
        builder
            .ToTable("user_training");
        
        builder
            .Property(a => a.TrainingObservations)
            .HasColumnName("training_observation")
            .IsRequired();

        builder
            .HasKey(ut =>   ut.Id );

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