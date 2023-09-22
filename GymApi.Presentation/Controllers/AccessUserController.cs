using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessUserController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinAge")]
    public IActionResult IsValid()
    {
        return Ok("user valid!");
    }
}