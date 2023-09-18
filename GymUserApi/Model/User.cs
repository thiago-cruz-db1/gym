using Microsoft.AspNetCore.Identity;

namespace GymUserApi.Model;

public class User : IdentityUser
{
    public DateTime DetailCompleted { get; set; }
    public User() : base() {}
}