using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Identity;
namespace GymApi.UseCases.Services;

public class LoginService
{
    private SignInManager<User> _signInManager;

    public LoginService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task Login(LoginUserRequest loginDto)
    {
       var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
       if (!result.Succeeded) throw new ApplicationException("User not auth");
    }
}