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
        var personalTrainer = _personalTrainerService.AddPersonalTrainer(personalTrainerDto);
        return Ok(personalTrainer);
    }

    [HttpGet]
    public IActionResult GetPersonalTrainers()
    {
        var personalTrainers = _personalTrainerService.GetPersonalTrainers();
        return Ok(personalTrainers);
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonalTrainerById(Guid id)
    {
        var personalTrainer = _personalTrainerService.GetPersonalTrainerById(id);
        if (personalTrainer == null!) return NotFound();
        return Ok(personalTrainer);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePersonalTrainerById(Guid id)
    {
        var personalTrainer = _personalTrainerService.DeletePersonalTrainerById(id);
        if (personalTrainer == null!) return NotFound();
        return Ok(personalTrainer);
    }
}