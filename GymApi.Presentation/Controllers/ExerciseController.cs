using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController
{
    private ExerciseService _exerciseService;

    public ExerciseController(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    public IActionResult CreateExercise([FromBody] CreateExerciseRequest createExerciseByTrainingDto)
    {
        try
        {
            var training = _exerciseService.AddExercise(createExerciseByTrainingDto);
            return new OkResult();
        }
        catch (Exception e)
        {
            throw new Exception("error on add Exercise",e);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetExercise()
    {
        try
        {
            var training = await _exerciseService.GetExercise();
            return new OkResult();
        }
        catch (Exception e)
        {
            throw new Exception("error on get Exercise",e);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetExerciseById(Guid id)
    {
        try
        {
            var training = await _exerciseService.GetExerciseById(id);
            return new OkResult();
        }
        catch (Exception e)
        {
            throw new Exception("error on get Exercise",e);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExerciseById(Guid id)
    {
        try
        {
            var training = await _exerciseService.UpdateExercise(id);
            return new OkResult();
        }
        catch (Exception e)
        {
            throw new Exception("error on update Exercise",e);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExerciseById(Guid id)
    {
        try
        {
            _exerciseService.DeleteExerciseById(id);
            return new NoContentResult();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete Exercise",e);
        }
    }
}