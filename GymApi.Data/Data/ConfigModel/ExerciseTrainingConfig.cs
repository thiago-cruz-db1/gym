using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class ExerciseTrainingConfig : IEntityTypeConfiguration<ExerciseTraining>
{
    public void Configure(EntityTypeBuilder<ExerciseTraining> builder)
    {
        builder
            .ToTable("exercise_training");

        builder
            .HasKey(ut => new { ut.ExerciseId, ut.TrainingId });

        builder
            .HasOne(ut => ut.Exercise)
            .WithMany(u => u.ExerciseTrainings)
            .HasForeignKey(ut => ut.ExerciseId);
        
        builder
            .HasOne(ut => ut.Training)
            .WithMany(t => t.ExerciseTrainings)
            .HasForeignKey(ut => ut.TrainingId);
    }
}