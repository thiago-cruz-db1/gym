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
            .Property(a => a.Name)
            .HasColumnType("varchar()45")
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