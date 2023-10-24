using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases.Services;

public class LoginUserService
{
    private readonly SignInManager<User> _signInManager;
    private readonly GenerateTokenService _generateTokenService;

    public LoginUserService(SignInManager<User> signInManager, GenerateTokenService generateTokenService)
    {
        _signInManager = signInManager;
        _generateTokenService = generateTokenService;
    }
    public async Task<string> Login(LoginUserRequest loginDto)
    {
	    var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
        if (!result.Succeeded) throw new ApplicationException("User not auth");
        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.UserName);
        if (user != null)
        {
            var token = _generateTokenService.Create(user);
            return token;
        }

        return "user is null";
    }
}