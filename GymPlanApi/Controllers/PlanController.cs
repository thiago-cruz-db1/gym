using AutoMapper;
using GymPlanApi.Data;
using GymPlanApi.Model;
using GymPlanApi.Model.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace GymPlanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private PlanContext _context;
        private IMapper _mapper;

        public PlanController(PlanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddPlan([FromBody] AddPlanRequest planDto)
        {
            Plan plan = _mapper.Map<Plan>(planDto);
            _context.Plans.Add(plan);
            _context.SaveChanges();
            return Ok(plan);
        }

        [HttpGet]
        public IActionResult GetPlans()
        {
            return Ok(_context.Plans.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(Guid id)
        {
            var plan = _context.Plans.FirstOrDefault(plan => plan.Id == id);
            if(plan == null) return NotFound();
            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlanById(Guid id)
        {
            var plan = _context.Plans.FirstOrDefault(plan => plan.Id == id);
            if (plan == null) return NotFound();

            _context.Remove(plan);
            _context.SaveChanges();
            return Ok(plan);
        }
    }
}
