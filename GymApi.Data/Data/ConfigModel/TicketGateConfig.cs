using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class TicketGateConfig : IEntityTypeConfiguration<TicketGate>
{
    public void Configure(EntityTypeBuilder<TicketGate> builder)
    {
        builder
            .ToTable("ticket_gate");
    }
}