using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel
{
    internal class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder
                .ToTable("plans");

            builder
                .Property(a => a.Id)
                .HasColumnName("plan_id");

            builder
                .Property(a => a.Category)
                .HasColumnName("category")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
               .Property(a => a.Amount)
               .HasColumnName("plan_price")
               .HasColumnType("double")
               .IsRequired();
            
            builder
                .Property(a => a.DayOfWeeks)
                .HasColumnName("day_of_week_plan")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property<DateTime>("create_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder
                .Property(a => a.TotalMonths)
                .HasColumnName("plan_duration")
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}