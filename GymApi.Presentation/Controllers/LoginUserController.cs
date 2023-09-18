using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginUserController : ControllerBase
{
    private readonly LoginUserUseCase _loginUserUseCase;
    
    public LoginUserController(LoginUserUseCase loginUserUseCase)
    {
        _loginUserUseCase = loginUserUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest loginDto)
    {
        var token = await _loginUserUseCase.Login(loginDto);
        return Ok(token);
    }
}