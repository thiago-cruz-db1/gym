namespace GymApi.Domain.Dto.Request;

public class CreateExerciseRequest
{
    public string Machine { get; set; }
    public string Pause { get; set; }
    public string Set { get; set; }
    public string Repetition { get; set; }
    public string Technique { get; set; }
}