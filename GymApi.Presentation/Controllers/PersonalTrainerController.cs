using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalTrainerController : ControllerBase
{
    private readonly GymDbContext _context;
    private readonly IMapper _mapper;

    public PersonalTrainerController(GymDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddPlan([FromBody] AddPersonalTrainerRequest personalTrainerDto)
    {
        PersonalTrainer personalTrainer = _mapper.Map<PersonalTrainer>(personalTrainerDto);
        _context.PesonalTrainers.Add(personalTrainer);
        _context.SaveChanges();
        return Ok(personalTrainer);
    }

    [HttpGet]
    public IActionResult GetPersonalTrainers()
    {
        return Ok(_context.PesonalTrainers.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonalTrainerById(Guid id)
    {
        var personalTrainer = _context.PesonalTrainers.FirstOrDefault(personalTrainer => personalTrainer.Id == id);
        if(personalTrainer == null) return NotFound();
        return Ok(personalTrainer);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePersonalTrainerById(Guid id)
    {
        var personalTrainer = _context.PesonalTrainers.FirstOrDefault(personalTrainer => personalTrainer.Id == id);
        if (personalTrainer == null) return NotFound();

        _context.Remove(personalTrainer);
        _context.SaveChanges();
        return Ok(personalTrainer);
    }
}