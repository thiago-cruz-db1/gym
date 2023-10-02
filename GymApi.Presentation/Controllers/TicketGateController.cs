using GymApi.UseCases.Interfaces;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketGateController: ControllerBase
{
    private readonly ITicketGate _ticketGateService;

    public TicketGateController(ITicketGate ticketGateService)
    {
        _ticketGateService = ticketGateService;
    }
    
    [HttpGet]
    public IActionResult AbleToPass([FromQuery] string id)
    {
        var valid = _ticketGateService.VerifyIfValid(id);
        if (valid)
        {
            return Ok("user Valid");

        }
        return NotFound("nem vem");
    }
}