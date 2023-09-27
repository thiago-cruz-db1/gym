namespace GymApi.Domain.Dto.Request;

public class CreateTrainingRequest
{
    public Guid Id { get; set; }
    public string Machine { get; set; }
    public string Pause { get; set; }
    public string Set { get; set; }
    public string Repetition { get; set; }
    public string Technique { get; set; }
}