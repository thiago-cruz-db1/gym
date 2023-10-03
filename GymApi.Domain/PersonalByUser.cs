namespace GymApi.Domain;

public class PersonalByUser
{
    public Guid Id { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public Guid PersonalId { get; set; }
    public PersonalTrainer PersonalTrainer { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime StartAt { get; set; } 
    public DateTime EndAt { get; set; }

    public double DiffPersonalHours
    {
        get
        {
            TimeSpan timeDifference = EndAt - StartAt;
            return timeDifference.TotalMinutes;
        }
        set { }
    }
}