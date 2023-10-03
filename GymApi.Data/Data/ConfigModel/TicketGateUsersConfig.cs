using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class TicketGateUsersConfig : IEntityTypeConfiguration<TicketGateUser>
{
    public void Configure(EntityTypeBuilder<TicketGateUser> builder)
    {
        builder
            .ToTable("ticketgate_user");

        builder
            .HasKey(ut =>  ut.Id );

        builder
            .HasOne(ut => ut.User)
            .WithMany(u => u.TicketGateUsers)
            .HasForeignKey(ut => ut.UserId);
        
        builder
            .HasOne(ut => ut.TicketGate)
            .WithMany(t => t.TicketGateUsers)
            .HasForeignKey(ut => ut.TicketGateId);
    }
}