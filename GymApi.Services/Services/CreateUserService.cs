using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases.Services;

public class CreateUserService
{
    private readonly ICreateUserRepositorySql _createUser;
    private readonly IMapper _mapper;

    public CreateUserService(IMapper mapper, ICreateUserRepositorySql createUser)
    {
        _mapper = mapper;
        _createUser = createUser;
    }

    public async Task<CreateUserResponse> Create(CreateUserRequest createDto)
    {
        User user = _mapper.Map<User>(createDto);
        await _createUser.Create(user, createDto);
        var userResponse = _mapper.Map<CreateUserResponse>(user);
        return userResponse;
    }
    
    public List<User> GetUsers()
    {
        List<User> user = _createUser.GetUsers();
        return user;
    }
    
    public async Task<User> GetUserById(string userId)
    {
        User user = await _createUser.GetUserById(userId);
        return user;
    }

    public async Task Update(string userId, UpdateUserRequest updateUserDto)
    {
        User user = await _createUser.GetUserById(userId);
        if (user == null) throw new ApplicationException("User not found");
        _mapper.Map(updateUserDto, user); 
        IdentityResult updated = await _createUser.Update(user);
        if (!updated.Succeeded) throw new ApplicationException("Error on updating user");
    }

    public async Task Delete(string userId)
    {
        User user = await _createUser.GetUserById(userId);
        if (user == null) throw new ApplicationException("User not found");

        IdentityResult deleted = await _createUser.Delete(user);

        if (!deleted.Succeeded) throw new ApplicationException("Error on deleting user");
    }

    public Task IncreaseWorkOut(string userId)
    {
        return _createUser.IncreaseWorkOut(userId);
    }

    public List<PersonalByUser> GetPersonalTraineeByDay(Guid id, DateTime date)
    {
        return _createUser.GetPersonalTraineeByDay(id, date);
    }
}