namespace GymApi.Domain;

public class Exercise
{
    public Guid Id { get; set; }
    public string Machine { get; set; }
    public string Pause { get; set; }
    public string Set { get; set; }
    public string Repetition { get; set; }
    public string Technique { get; set; }
    public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
}