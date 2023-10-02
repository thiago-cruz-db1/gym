namespace GymApi.Domain;

public class TicketGate
{
    public Guid Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int TrainingDays { get; set; }
}