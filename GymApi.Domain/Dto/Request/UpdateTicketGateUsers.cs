namespace GymApi.Domain.Dto.Request;

public class UpdateTicketGateUsers
{
    public Guid? UserId { get; set; }
    public string? TicketGateId { get; set; }
}