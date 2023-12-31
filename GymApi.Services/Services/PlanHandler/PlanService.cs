﻿using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services.PlanHandler;

public class PlanService : AbstractPlanValidator
{
    private readonly IMapper _mapper;
    private readonly IPlanRepositorySql _contextPlan;

    public PlanService(IPlanRepositorySql contextPlan, IMapper mapper, IValidatorPlan validatorPlan) : base(validatorPlan)
    {
        _contextPlan = contextPlan;
        _mapper = mapper;
    }

    public async Task<Domain.Plan> AddPlan(CreatePlanCommand planDto)
    {
	    var duplicateName = await IsValidPlanName(planDto.Category);
	    if (duplicateName) throw new Exception("plan with this name already exist");

	    var plan = _mapper.Map<Domain.Plan>(planDto);
	    plan.Validate();
	    await _contextPlan.Save(plan);
	    await _contextPlan.SaveChange();
	    return plan;
    }

    public async Task<ICollection<Domain.Plan>> GetPlans()
    {
        return await _contextPlan.FindAll();
    }

    public async Task<Domain.Plan> GetPlanById(Guid id)
    {
        return await _contextPlan.FindById(id);
    }

    public async Task<Domain.Plan> UpdatePlanById(Guid id, UpdatePlanCommand updatePlanDto)
    {
        var plan = await _contextPlan.FindById(id);
        if (plan == null) throw new ApplicationException("plan not found");
        var pl = _mapper.Map(updatePlanDto, plan);
        pl.Validate();
        await _contextPlan.Update(plan);
        await _contextPlan.SaveChange();
        return plan;
    }

    public async Task DeletePlanById(Guid id)
    {
        var plan = await _contextPlan.FindById(id);
        _contextPlan.Delete(plan);
        await _contextPlan.SaveChange();
    }
}