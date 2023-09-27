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
        public IActionResult AddPlan([FromBody] CreatePlanRequest planDto)
        {
            try
            {
                var plan = _planService.AddPlan(planDto);
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on create plan", e);
            }
        }

        [HttpGet]
        public IActionResult GetPlans()
        {
            try
            {
                var plans = _planService.GetPlans();
                return Ok(plans);
            }
            catch (Exception e)
            {
                throw new Exception("error on get plan", e);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(Guid id)
        {
            try
            {
                var plan = _planService.GetPlanById(id);
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
        public IActionResult DeletePlanById(Guid id)
        {
            try
            {
                _planService.DeletePlanById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception("error on delete plan", e);
            }
        }
    }
}
