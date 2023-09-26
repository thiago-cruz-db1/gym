using AutoMapper;
using GymApi.Data;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class PlanService
{
    private readonly IMapper _mapper;
    private readonly IPlanRepository _contextPlan;

    public PlanService(IPlanRepository contextPlan, IMapper mapper)
    {
        _contextPlan = contextPlan;
        _mapper = mapper;
    }

    public Plan AddPlan(AddPlanRequest planDto)
    {
        var plan = _mapper.Map<Plan>(planDto);
        _contextPlan.Save(plan);
        return plan;
    }

    public async Task<ICollection<Plan>> GetPlans()
    {
        return await _contextPlan.FindAll();
    }

    public async Task<Plan> GetPlanById(Guid id)
    {
        return await _contextPlan.FindById(id);
    }

    public async void DeletePlanById(Guid id)
    {
        var plan = await _contextPlan.FindById(id);
        _contextPlan.Delete(plan);
    }
}