using Microsoft.AspNetCore.Identity;

namespace GymApi.Domain;

public class User : IdentityUser
{
    public DateTime DetailCompleted { get; set; }
    public User() : base() {}
}