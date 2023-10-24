using GymApi.Domain;
using Microsoft.AspNetCore.Identity;

namespace GymApi.Data.Data.Interfaces;

public interface ICreateUserRepositorySql
{
    public Task Create(User user, string createDto);
    public List<User> GetUsers();
    public Task<User> GetUserById(string userId);
    public Task<IdentityResult>  Update(User user);
    public Task<IdentityResult> Delete(User user);
    public Task IncreaseWorkOut(string userId);
    public List<PersonalByUser> GetPersonalTraineeByDay(Guid id, DateTime date);
}