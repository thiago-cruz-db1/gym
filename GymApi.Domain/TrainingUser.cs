namespace GymApi.Domain;

public class TrainingUser
{
    public Guid Id { get; set; }
    public string TrainingObservations { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }
}