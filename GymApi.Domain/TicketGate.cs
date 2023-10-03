using System.Diagnostics.Metrics;

namespace GymApi.Domain;

public class TicketGate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<TicketGateUser> TicketGateUsers { get; set; }
}