namespace GymApi.Domain;

public class Exercise
{
    public Guid Id { get; set; }
    public string Machine { get; set; }
    public int Pause { get; set; }
    public int Set { get; set; }
    public int Repetition { get; set; }
    public string Technique { get; set; }
    public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
}