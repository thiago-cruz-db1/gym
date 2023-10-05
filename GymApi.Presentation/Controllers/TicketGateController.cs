using GymApi.Domain;
using GymApi.Domain.Enum;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketGateController: ControllerBase
{
    [HttpGet]
    public IActionResult AbleToPass([FromQuery] TicketGate pass)
    {
        return Ok("nothing");
    }
}