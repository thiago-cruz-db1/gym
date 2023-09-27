using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
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
    public IActionResult AddPersonalTrainer([FromBody] AddPersonalTrainerRequest personalTrainerDto)
    {
        try
        {
            var personalTrainer = _personalTrainerService.AddPersonalTrainer(personalTrainerDto);
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on add personal",e);
        }
    }

    [HttpGet]
    public IActionResult GetPersonalTrainers()
    {
        try
        {
            var personalTrainers = _personalTrainerService.GetPersonalTrainers();
            return Ok(personalTrainers);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personal",e);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonalTrainerById(Guid id)
    {
        try
        {
            var personalTrainer = _personalTrainerService.GetPersonalTrainerById(id);
            if (personalTrainer == null!) return NotFound();
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on get personal",e);
        }
    }
        
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonalById(Guid id)
    {
        try
        {
            var personalTrainer = await _personalTrainerService.UpdatePernalById(id);
            return Ok(personalTrainer);
        }
        catch (Exception e)
        {
            throw new Exception("error on update personal",e);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePersonalTrainerById(Guid id)
    {
        try
        {
            _personalTrainerService.DeletePersonalTrainerById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete personal",e);
        }
    }
}