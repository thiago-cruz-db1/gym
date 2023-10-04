using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;
using Microsoft.AspNetCore.Identity;

namespace GymApi.Data.Data.Repositories;

public class CreateUserRepositorySql : ICreateUserRepositorySql
{
    private readonly GymDbContext _contextUser;
    private readonly UserManager<User> _userManager;
    public CreateUserRepositorySql(GymDbContext context, UserManager<User> userManager)
    {
        _contextUser = context;
        _userManager = userManager;
    } 
    public async Task Create(User user, CreateUserRequest createDto)
    {
        IdentityResult created = await _userManager.CreateAsync(user, createDto.Password);
        if (!created.Succeeded) throw new ApplicationException("Error on create user");
    }

    public List<User> GetUsers()
    {
        return _userManager.Users.ToList();
    }

    public Task<User> GetUserById(string userId)
    {
        return _userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> Update(User user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> Delete(User user)
    {
        return await _userManager.DeleteAsync(user);
    }

    public async Task IncreaseWorkOut(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        user.TrainingDays++;
        await _contextUser.SaveChangesAsync();
    }

    public List<PersonalByUser> GetPersonalTraineeByDay(Guid id, DateTime date)
    {
        return _contextUser.PersonalByUsers.Where(e => e.StartAt.Date == date.Date && e.PersonalId == id).ToList();
    }
}