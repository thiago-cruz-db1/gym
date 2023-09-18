using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases;

public class CreateUserUseCase
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    
    public CreateUserUseCase(IMapper mapper, UserManager<User> userManage)
    {
        _mapper = mapper;
        _userManager = userManage;
    }
    public async Task execute(CreateLoginUserRequest loginDto)
    {
        User user = _mapper.Map<User>(loginDto);
        //creating user
        IdentityResult created = await _userManager.CreateAsync(user, loginDto.Password);
        if (!created.Succeeded) throw new ApplicationException("Error on create user");
    }
}