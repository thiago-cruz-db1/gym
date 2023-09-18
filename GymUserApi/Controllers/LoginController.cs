using GymUserApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class LoginController
{
    [HttpPost]
    public IActionResult CreateLogin(CreateLoginUserRequest loginDto)
    {
        throw new Exception();
    }
}
