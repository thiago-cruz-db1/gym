using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class PersonalTrainerConfig : IEntityTypeConfiguration<PersonalTrainer>
{
    public void Configure(EntityTypeBuilder<PersonalTrainer> builder)
    {
        builder
            .ToTable("personal_trainer");
        
        builder
            .Property(pt => pt.Id)
            .HasColumnName("personal_trainer_id");

        builder
            .Property(pt => pt.Age)
            .IsRequired();
        
        builder
            .Property(pt => pt.Name)
            .HasColumnName("personal_trainer_name")
            .IsRequired();
        
        builder
            .Property<DateTime>("create_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}