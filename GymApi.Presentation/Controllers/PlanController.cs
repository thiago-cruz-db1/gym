using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
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
        public IActionResult AddPlan([FromBody] AddPlanRequest planDto)
        {
            var plan = _planService.AddPlan(planDto);
            return Ok(plan);
        }

        [HttpGet]
        public IActionResult GetPlans()
        {
            var plans = _planService.GetPlans();
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(Guid id)
        {
            var plan = _planService.GetPlanById(id);
            if (plan == null!) return NotFound();
            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlanById(Guid id)
        {
            var plan = _planService.DeletePlanById(id);
            if (plan == null!) return NotFound();
            return Ok(plan);
        }
    }
}
