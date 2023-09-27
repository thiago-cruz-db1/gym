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
        public IActionResult AddPlan([FromBody] CreateExerciseByTrainingRequest exerciseByTrainingDto)
        {
            try
            {
                var exerciseByTraining = _exerciseByTrainingService.AddExerciseTraining(exerciseByTrainingDto);
                return Ok(exerciseByTraining);
            }
            catch (Exception e)
            {
                throw new Exception("error on create ExerciseByTraining", e);
            }
        }

        [HttpGet]
        public IActionResult GetPlans()
        {
            try
            {
                var exerciseByTraining = _exerciseByTrainingService.GetExerciseTraining();
                return Ok(exerciseByTraining);
            }
            catch (Exception e)
            {
                throw new Exception("error on get ExerciseByTraining", e);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(Guid id)
        {
            try
            {
                var exerciseByTraining = _exerciseByTrainingService.GetExerciseTrainingById(id);
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
        public IActionResult DeletePlanById(Guid id)
        {
            try
            {
                _exerciseByTrainingService.DeleteExerciseTrainingById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception("error on delete ExerciseByTraining", e);
            }
        }
}