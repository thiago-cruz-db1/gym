using FluentValidation;
using FluentValidation.Results;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
	    private readonly IValidator<CreatePlanRequest> _validator;
        private readonly PlanService _planService;

        public PlanController(PlanService planService, IValidator<CreatePlanRequest> validator)
        {
	        _planService = planService;
	        _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] CreatePlanRequest planDto)
        {
	        var result = await _validator.ValidateAsync(planDto);
	        if (!result.IsValid)
	        {
		        throw new Exception("same validations are not done");
	        }
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
        public async Task<IActionResult> UpdatePlanById(Guid id, [FromBody] UpdatePlanRequest updatePlanDto)
        {
            try
            {
                var plan = await _planService.UpdatePlanById(id, updatePlanDto);
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
