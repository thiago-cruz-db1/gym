using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalByUserController: ControllerBase
{
    private readonly PersonalByUserService _personalByUserService;

    public PersonalByUserController(PersonalByUserService personalByUserService)
    {
        _personalByUserService = personalByUserService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonalByUser([FromBody] CreatePersonalByUserRequest personalByUserDto)
    {
        try
        {
            var personalByUser = await _personalByUserService.AddPersonalByUser(personalByUserDto);
            return Ok(personalByUser);
        }
        catch (Exception e)
        {
            throw new Exception("error on create personalByUser", e);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonalByUser()
    {
        try
        {
            var personalByUser = await _personalByUserService.GetPersonalByUser();
            return Ok(personalByUser);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personalByUser", e);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonalByUserById(Guid id)
    {
        try
        {
            var personalByUser = await _personalByUserService.GetPersonalByUserById(id);
            if (personalByUser == null!) return NotFound();
            return Ok(personalByUser);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personalByUser", e);
        }

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonalByUserById(Guid id, [FromBody] UpdatePersonalByUserRequest updatePersonalByUserDto)
    {
        try
        {
            var personalByUser = await _personalByUserService.UpdatePersonalByUserById(id, updatePersonalByUserDto);
            return Ok(personalByUser);
        }
        catch (Exception e)
        {
            throw new Exception("error on update plan", e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonalByUserById(Guid id)
    {
        try
        {
            await _personalByUserService.DeletePersonalByUserById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete plan", e);
        }
    }
}