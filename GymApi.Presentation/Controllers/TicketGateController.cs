using GymApi.Domain;
using GymApi.UseCases.Interfaces;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketGateController: ControllerBase
{
    private readonly CreateUserService _createUserService;
    private readonly TicketGateService _ticketGateService;

    public TicketGateController(TicketGateService ticketGateService, CreateUserService createUserService)
    {
        _ticketGateService = ticketGateService;
        _createUserService = createUserService;
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