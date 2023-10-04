namespace GymApi.Domain.Dto.Request;

public class UpdateTrainingRequest
{
    public string? Name { get; set; }
    public ICollection<Guid>? Exercises { get; set; }
}