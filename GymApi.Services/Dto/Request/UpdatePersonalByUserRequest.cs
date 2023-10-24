namespace GymApi.UseCases.Dto.Request;


public class UpdatePersonalByUserRequest
{
    public Guid? UserId { get; set; }
    public Guid? PersonalId { get; set; }
    public DateTime? StartAt { get; set; } = DateTime.Now;
    public DateTime? EndAt { get; set; }
}