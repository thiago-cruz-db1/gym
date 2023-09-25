using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class PlanService
{
    private readonly GymDbContext _context;
    private readonly IMapper _mapper;

    public PlanService(GymDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Plan AddPlan(AddPlanRequest planDto)
    {
        var plan = _mapper.Map<Plan>(planDto);
        _context.Plans.Add(plan);
        _context.SaveChanges();
        return plan;
    }

    public List<Plan> GetPlans()
    {
        return _context.Plans.ToList();
    }

    public Plan GetPlanById(Guid id)
    {
        return _context.Plans.FirstOrDefault(plan => plan.Id == id);
    }

    public Plan DeletePlanById(Guid id)
    {
        var plan = _context.Plans.FirstOrDefault(plan => plan.Id == id);
        if (plan == null) return null;

        _context.Remove(plan);
        _context.SaveChanges();
        return plan;
    }
}