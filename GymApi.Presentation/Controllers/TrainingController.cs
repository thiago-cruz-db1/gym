﻿using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainingController : ControllerBase
{
    private readonly TrainingService _trainingService;
    public TrainingController(TrainingService trainingService)
    {
        _trainingService = trainingService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingRequest createTrainingDto)
    {
        try
        {
            var training = await _trainingService.AddTraining(createTrainingDto);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on add training",e);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTraining()
    {
        try
        {
            var training = await _trainingService.GetTraining();
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on get training",e);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrainingById(Guid id)
    {
        try
        {
            var training = await _trainingService.GetTrainingById(id);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on get training",e);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrainingById(Guid id)
    {
        try
        {
            var training = await _trainingService.UpdateTraining(id);
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on update training",e);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrainingById(Guid id)
    {
        try
        {
            await _trainingService.DeleteTrainingById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete training",e);
        }
    }
}