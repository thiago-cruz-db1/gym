using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginUserController : ControllerBase
{
    private readonly LoginUserService _loginUserService;

    public LoginUserController(LoginUserService loginUserService)
    {
        _loginUserService = loginUserService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest loginDto)
    {
        var token = await _loginUserService.Login(loginDto);
        return Ok(token);
    }
}