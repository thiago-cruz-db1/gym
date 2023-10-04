using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;
using Microsoft.AspNetCore.Identity;

namespace GymApi.Data.Data.Interfaces;

public interface ICreateUserRepositorySql
{
    public Task Create(User user, CreateUserRequest createDto);
    public List<User> GetUsers();
    public Task<User> GetUserById(string userId);
    public Task<IdentityResult>  Update(User user);
    public Task<IdentityResult> Delete(User user);
    public Task IncreaseWorkOut(string userId);
    public List<PersonalByUser> GetPersonalTraineeByDay(Guid id, DateTime date);
}