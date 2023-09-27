namespace GymApi.Domain.Dto.Request;

public class UpdateTrainingRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Guid> Exercises { get; set; }
}