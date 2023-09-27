using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseByTrainingController : ControllerBase
{
     private readonly ExerciseByTrainingService _exerciseByTrainingService;

        public ExerciseByTrainingController(ExerciseByTrainingService exerciseByTrainingService)
        {
            _exerciseByTrainingService = exerciseByTrainingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] CreateExerciseByTrainingRequest exerciseByTrainingDto)
        {
            try
            {
                var exerciseByTraining = await _exerciseByTrainingService.AddExerciseTraining(exerciseByTrainingDto);
                return Ok(exerciseByTraining);
            }
            catch (Exception e)
            {
                throw new Exception("error on create ExerciseByTraining", e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var exerciseByTraining = await _exerciseByTrainingService.GetExerciseTraining();
                return Ok(exerciseByTraining);
            }
            catch (Exception e)
            {
                throw new Exception("error on get ExerciseByTraining", e);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(Guid id)
        {
            try
            {
                var exerciseByTraining = await _exerciseByTrainingService.GetExerciseTrainingById(id);
                if (exerciseByTraining == null!) return NotFound();
                return Ok(exerciseByTraining);
            }
            catch (Exception e)
            {
                throw new Exception("error on get ExerciseByTraining", e);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanById(Guid id)
        {
            try
            {
                var plan = await _exerciseByTrainingService.UpdateExerciseTraining(id);
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on update ExerciseByTraining", e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanById(Guid id)
        {
            try
            {
                await _exerciseByTrainingService.DeleteExerciseTrainingById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception("error on delete ExerciseByTraining", e);
            }
        }
}