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
            .HasColumnType("varchar(45)")
            .HasColumnName("training_name")
            .IsRequired();

        builder
            .Property(a => a.StartDate)
            .HasColumnName("start_date")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .Property(a => a.EndDate)
            .HasColumnName("end_date")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder
            .Property<DateTime>("create_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}