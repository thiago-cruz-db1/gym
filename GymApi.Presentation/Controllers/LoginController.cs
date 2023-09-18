using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Presentation.Controllers;

[ApiController]
[Route("[Controller]")]
public class LoginController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public LoginController(IMapper mapper, UserManager<User> userManage)
    {
        _mapper = mapper;
        _userManager = userManage;
    }
    [HttpPost]
    public async Task<IActionResult> CreateLogin(CreateLoginUserRequest loginDto)
    {
        User user = _mapper.Map<User>(loginDto);
        //creating user
        IdentityResult created = await _userManager.CreateAsync(user, loginDto.Password);

        if (created.Succeeded) return Ok("user created");

        throw new ApplicationException("Error on create user");
    }
}
