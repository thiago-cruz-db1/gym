using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Presentation.Controllers;

[ApiController]
[Route("[Controller]")]
public class CreateUserController : ControllerBase
{
    private CreateUserService _createUserService;

    public CreateUserController(CreateUserService useCaseService)
    {
        _createUserService = useCaseService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLogin(CreateLoginUserRequest createLoginDto)
    {
        await _createUserService.Create(createLoginDto);
        return Ok("user created");
    }
}
