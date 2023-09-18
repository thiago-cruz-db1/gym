using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginUserController : ControllerBase
{
    private LoginService _loginService;
    
    public LoginUserController(LoginService loginService)
    {
        _loginService = loginService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest loginDto)
    {
        await _loginService.Login(loginDto);
        return Ok("User auth!");
    }
}