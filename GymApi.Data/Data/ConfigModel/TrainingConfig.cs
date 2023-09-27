using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class TrainingConfig : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder
            .ToTable("training");

        builder
            .Property(a => a.Id)
            .HasColumnName("training_id");

        builder
            .Property(a => a.Machine)
            .HasColumnName("machine")
            .HasColumnType("varchar(45)")
            .IsRequired();

        builder
            .Property(a => a.Pause)
            .HasColumnName("set_pause")
            .HasColumnType("varchar(45)")
            .IsRequired();
        
        builder
            .Property(a => a.Set)
            .HasColumnName("set_training")
            .HasColumnType("varchar(45)")
            .IsRequired();
        
        builder
            .Property(a => a.Repetition)
            .HasColumnName("set_repetition")
            .HasColumnType("varchar(2)")
            .IsRequired();
        
        builder
            .Property(a => a.Technique)
            .HasColumnName("set_techique")
            .HasColumnType("varchar(45)")
            .IsRequired();

        builder
            .Property(a => a.StartDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder
            .Property(a => a.EndDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}