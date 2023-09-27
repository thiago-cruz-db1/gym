using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainingByUserController : ControllerBase
{
    private TrainingByUserService _trainingByUserService;

    public TrainingByUserController(TrainingByUserService trainingByUserService)
    {
        _trainingByUserService = trainingByUserService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingByUserRequest createTrainingDto)
    {
        try
        {
            var training = await _trainingByUserService.AddTrainingUser(createTrainingDto);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on add training by user",e);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTraining()
    {
        try
        {
            var training = await _trainingByUserService.GetTrainingUser();
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on get training user",e);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrainingById(Guid id)
    {
        try
        {
            var training = await _trainingByUserService.GetTrainingUserById(id);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on get training user",e);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrainingById(Guid id)
    {
        try
        {
            var training = await _trainingByUserService.UpdateTrainingUser(id);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on update training user",e);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrainingById(Guid id)
    {
        try
        {
            await _trainingByUserService.DeleteTrainingUserById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete training user",e);
        }
    }
}