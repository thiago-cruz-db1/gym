namespace GymApi.Domain;

public class TrainingUser
{
    public Guid Id { get; set; }
    public ICollection<string> TrainingObservations { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }
}