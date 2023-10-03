namespace GymApi.Domain.Dto.Request;

public class CreateTicketGateUsers
{
    public Guid UserId { get; set; }
    public string TicketGateId { get; set; }
}