namespace GymApi.Domain.Dto.Request;

public class CreateTicketGateUsersRequest
{
    public Guid UserId { get; set; }
    public string TicketGateId { get; set; }
    public DateTime day { get; set; }
}