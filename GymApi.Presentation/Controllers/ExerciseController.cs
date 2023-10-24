using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly ExerciseService _exerciseService;

    public ExerciseController(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseRequest createExerciseDto)
    {
        try
        {
            var training = await _exerciseService.AddExercise(createExerciseDto);
            return Ok(training);
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
            return Ok(training);
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
            return Ok(training);
        }
        catch (Exception e)
        {
            throw new Exception("error on get Exercise",e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExerciseById(Guid id, [FromBody] UpdateExerciseRequest updateExerciseDto)
    {
        try
        {
            var training = await _exerciseService.UpdateExercise(id, updateExerciseDto);
            return Ok(training);
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
            await _exerciseService.DeleteExerciseById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete Exercise",e);
        }
    }

    [HttpPost("/upload")]
    public async Task<IActionResult> UploadTableOfExercise(IFormFile file)
    {
	    if (file is null || file.Length <= 0)
	    {
		    throw new ArgumentNullException(nameof(file), "File is empty or null.");
	    }

	    var dataFileName = Path.GetFileName(file.FileName);

	    var extension = Path.GetExtension(dataFileName);

	    var allowedExtsnions = new[] { ".xls", ".xlsx"};
	    if (!allowedExtsnions.Contains(extension))
		    throw new Exception("Sorry! This file is not allowed, make sure that file having extension as either .xls or .xlsx is uploaded.");
	    var upload = await _exerciseService.UploadTableOfExercise(file);
	    if(upload) return Ok("done");
	    throw new Exception("something went wrong with your upload");
    }
}