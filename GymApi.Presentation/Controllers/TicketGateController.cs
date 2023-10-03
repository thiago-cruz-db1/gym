using GymApi.Domain;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketGateController: ControllerBase
{
    private readonly CreateUserService _createUserService;
    private readonly TicketGateService _ticketGateService;
    private readonly TicketGateUserService _ticketGateUserService;

    public TicketGateController(TicketGateService ticketGateService, CreateUserService createUserService, TicketGateUserService ticketGateUserService)
    {
        _ticketGateService = ticketGateService;
        _createUserService = createUserService;
        _ticketGateUserService = ticketGateUserService;
    }
    
    [HttpGet]
    public IActionResult AbleToPass([FromQuery] TicketGate pass)
    {
        var valid = _ticketGateService.VerifyIfValid(pass.Id.ToString());
        if (valid)
        {
            _createUserService.IncreaseWorkOut(pass.Id.ToString());
            return Ok("user Valid");
        }
        return NotFound("nem vem");
    }
}