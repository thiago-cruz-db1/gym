namespace GymApi.UseCases.Dto.Request;

public class CreateTrainingRequest
{
    public string Name { get; set; }
    public ICollection<Guid> Exercises { get; set; }
}