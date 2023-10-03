using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class PersonalByUserConfig : IEntityTypeConfiguration<PersonalByUser>
{
    public void Configure(EntityTypeBuilder<PersonalByUser> builder)
    {
        builder
            .ToTable("personal_by_user");

        builder
            .HasKey(e => e.Id);

        builder
            .HasOne(e => e.User)
            .WithMany(e => e.PersonalByUsers)
            .HasForeignKey(e => e.UserId);

        builder
            .HasOne(e => e.PersonalTrainer)
            .WithMany(e => e.PersonalByUsers)
            .HasForeignKey(e => e.PersonalId);
    }
}