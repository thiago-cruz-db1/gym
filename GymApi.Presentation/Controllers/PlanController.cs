using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly PlanService _planService;

        public PlanController(PlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] CreatePlanRequest planDto)
        {
            try
            {
                var plan = await _planService.AddPlan(planDto);
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on create plan", e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var plans = await _planService.GetPlans();
                return Ok(plans);
            }
            catch (Exception e)
            {
                throw new Exception("error on get plan", e);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(Guid id)
        {
            try
            {
                var plan = await _planService.GetPlanById(id);
                if (plan == null!) return NotFound();
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on get plan", e);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanById(Guid id)
        {
            try
            {
                var plan = await _planService.UpdatePlanById(id);
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on update plan", e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanById(Guid id)
        {
            try
            {
                await _planService.DeletePlanById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception("error on delete plan", e);
            }
        }
    }
}
