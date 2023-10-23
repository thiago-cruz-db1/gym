namespace GymApi.Domain;

public class ExerciseTraining
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public Guid TrainingId { get; set; }
    public Training Training { get; set; }
}