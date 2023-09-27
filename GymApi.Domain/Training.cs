namespace GymApi.Domain;

public class Training
{
    public Guid Id { get; set; }
    public string Machine { get; set; }
    public string Pause { get; set; }
    public string Set { get; set; }
    public string Repetition { get; set; }
    public string Technique { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(2);
    
    public ICollection<UserTraining> UserTrainings { get; set; }
}