using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalTrainerController : ControllerBase
{
    private readonly PersonalTrainerService _personalTrainerService;

    public PersonalTrainerController(PersonalTrainerService personalTrainerService)
    {
        _personalTrainerService = personalTrainerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonalTrainer([FromBody] CreatePersonalTrainerRequest personalTrainerDto)
    {
        try
        {
            var personalTrainer = await _personalTrainerService.AddPersonalTrainer(personalTrainerDto);
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on add personal",e);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonalTrainers()
    {
        try
        {
            var personalTrainers = await _personalTrainerService.GetPersonalTrainers();
            return Ok(personalTrainers);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personal",e);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonalTrainerById(Guid id)
    {
        try
        {
            var personalTrainer = await _personalTrainerService.GetPersonalTrainerById(id);
            if (personalTrainer == null!) return NotFound();
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personal",e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonalById(Guid id, [FromBody] UpdatePersonalRequest updatePersonalDto)
    {
        try
        {
            var personalTrainer = await _personalTrainerService.UpdatePersonalById(id, updatePersonalDto);
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on update personal",e);
        }
    }

    [HttpGet("/userinday")]
    public IActionResult GetPersonalTraineeByDay(Guid id, int day)
    {
        try
        {
            var listUsersInDay = _personalTrainerService.GetUsersTraineeByDay(id, DateTime.Now.AddDays(day));
            return Ok(listUsersInDay);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonalTrainerById(Guid id)
    {
        try
        {
            await _personalTrainerService.DeletePersonalTrainerById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete personal",e);
        }
    }
}