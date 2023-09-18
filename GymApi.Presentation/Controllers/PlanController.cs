using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private GymDbContext _context;
        private IMapper _mapper;

        public PlanController(GymDbContext context, IMapper mapper)
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
