namespace GymApi.Domain;

public class Training
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(2);
    
    public ICollection<TrainingUser> UserTrainings { get; set; }
    public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
}