using System.Diagnostics.Metrics;

namespace GymApi.Domain;

public class TicketGate
{
    public Guid Id { get; set; }
    public DateTime? StartAt { get; set; } = DateTime.Now;
    public DateTime? EndAt { get; set; }
}