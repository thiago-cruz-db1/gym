namespace GymApi.UseCases.Dto.Request;

public class CreateExerciseRequest
{
    public string Machine { get; set; }
    public int Pause { get; set; }
    public int Set { get; set; }
    public int Repetition { get; set; }
    public string Technique { get; set; }
}