using GymUserApi.Model;
using GymUserApi.Profiles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymUserApi.Data;

public class UserDbContext : IdentityDbContext<User>
    
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts) {}
}