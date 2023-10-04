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
    private readonly IPlanRepositorySql _contextPlan;

    public PlanService(IPlanRepositorySql contextPlan, IMapper mapper)
    {
        _contextPlan = contextPlan;
        _mapper = mapper;
    }

    public async Task<Plan> AddPlan(CreatePlanRequest planDto)
    {
        var plan = _mapper.Map<Plan>(planDto);
        await _contextPlan.Save(plan);
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
    
    public async Task<Plan> UpdatePlanById(Guid id, UpdatePlanRequest updatePlanDto)
    {
        var plan = await _contextPlan.FindById(id);
        if (plan == null) throw new ApplicationException("plan not found");
        _mapper.Map(updatePlanDto, plan); 
        await _contextPlan.Update(plan);
        return plan;
    }

    public async Task DeletePlanById(Guid id)
    {
        var plan = await _contextPlan.FindById(id);
        _contextPlan.Delete(plan);
    }
}