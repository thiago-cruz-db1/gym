namespace GymApi.Domain;

public class TicketGateUser
{
    public Guid Id { get; set; }
    public DateTime StartAt { get; set; } = DateTime.Now;
    public DateTime? EndAt { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public Guid TicketGateId { get; set; }
    public TicketGate TicketGate { get; set; }
}