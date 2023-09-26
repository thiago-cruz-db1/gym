using Microsoft.AspNetCore.Identity;

namespace GymApi.Domain;

public class User : IdentityUser
{
    public DateTime DateBirth { get; set; }
    public string Address { get; set; }
    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
    public Guid PersonalTrainerId { get; set; }
    public PersonalTrainer PersonalTrainer { get; set; }
    public User() : base() {}
}