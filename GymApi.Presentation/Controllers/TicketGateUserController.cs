using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketGateUserController : ControllerBase
{
    private readonly TicketGateUserService _ticketGateUserService;

    public TicketGateUserController(TicketGateUserService ticketGateUserService)
    {
        _ticketGateUserService = ticketGateUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketGateUser()
    {
        try
        {
            var ticketGate = await _ticketGateUserService.GetTicketGateUser();
            return Ok(ticketGate);
        }
        catch (Exception e)
        {
            throw new Exception("error on get ticketGate", e);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketGateUserById(Guid id)
    {
        try
        {
            var ticketGate = await _ticketGateUserService.GetTicketGateUserById(id);
            if (ticketGate == null!) return NotFound();
            return Ok(ticketGate);
        }
        catch (Exception e)
        {
            throw new Exception("error on get ticketGate", e);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicketGateUserById(Guid id, [FromBody] UpdateTicketGateUsers ticketGateDto)
    {
        try
        {
            var ticketGate = await _ticketGateUserService.UpdateTicketGateUserById(id, ticketGateDto);
            return Ok(ticketGate);
        }
        catch (Exception e)
        {
            throw new Exception("error on update ticketGate", e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicketGateUserById(Guid id)
    {
        try
        {
            await _ticketGateUserService.DeleteTicketGateUserById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete ticketGate", e);
        }
    }

    [HttpPost("/send")]
    public async Task<IActionResult> GetAbleUsers([FromBody] CreateTicketGateUsersRequest ticketGateDto)
    {
        try
        {
            var validUser = await _ticketGateUserService.GetAbleUsers(ticketGateDto.day);
            var send = _ticketGateUserService.SendToTicketGate(validUser);
            return Accepted(send);
        }
        catch (Exception e)
        {
            throw new Exception("error on verify able users", e);
        }
    }
}