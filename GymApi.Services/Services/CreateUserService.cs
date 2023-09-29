using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases.Services;

public class CreateUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateUserService(IMapper mapper, UserManager<User> userManage)
    {
        _mapper = mapper;
        _userManager = userManage;
    }

    public async Task Create(CreateUserRequest createDto)
    {
        User user = _mapper.Map<User>(createDto);
        IdentityResult created = await _userManager.CreateAsync(user, createDto.Password);
        if (!created.Succeeded) throw new ApplicationException("Error on create user");
    }
    
    public async Task<List<User>> GetUsers()
    {
        List<User> user = _userManager.Users.ToList();
        return user;
    }
    
    public async Task<User> GetUserById(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public async Task Update(string userId, UpdateUserRequest updateUserDto)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new ApplicationException("User not found");

        _mapper.Map(updateUserDto, user); 
        IdentityResult updated = await _userManager.UpdateAsync(user);

        if (!updated.Succeeded) throw new ApplicationException("Error on updating user");
    }

    public async Task Delete(string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new ApplicationException("User not found");

        IdentityResult deleted = await _userManager.DeleteAsync(user);

        if (!deleted.Succeeded) throw new ApplicationException("Error on deleting user");
    }
}