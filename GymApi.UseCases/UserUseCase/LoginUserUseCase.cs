using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases.UserUseCase;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases;

public class LoginUserUseCase
{
    private readonly SignInManager<User> _signInManager;
    private readonly GenerateTokenUseCase _generateTokenUseCase;

    public LoginUserUseCase(SignInManager<User> signInManager, GenerateTokenUseCase generateTokenUseCase)
    {
        _signInManager = signInManager;
        _generateTokenUseCase = generateTokenUseCase;
    }
    public async Task<string> Login(LoginUserRequest loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
        if (!result.Succeeded) throw new ApplicationException("User not auth");
        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.UserName);
        if (user != null)
        {
            var token = _generateTokenUseCase.Create(user);
            return token;
        }

        return "user is null";
    }
}