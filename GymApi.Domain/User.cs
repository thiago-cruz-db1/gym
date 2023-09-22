using Microsoft.AspNetCore.Identity;

namespace GymApi.Domain;

public class User : IdentityUser
{
    public string DateBirth { get; set; }
    public string Address { get; set; }
    public User() : base() {}
}