using GymApi.Data.Data.Interfaces;
using GymApi.UseCases.Dto.Request;
using MediatR;

namespace GymApi.UseCases.Services.Plan;

public class GetByIdPlanCommandHandler
{
	private readonly IPlanRepositorySql _contextPlan;


	public GetByIdPlanCommandHandler(IPlanRepositorySql contextPlan)
	{
		_contextPlan = contextPlan;
	}

	public async Task<Domain.Plan> HandleGetById(Guid id)
	{
		try
		{
			var plan = await _contextPlan.FindById(id);
			return plan;
		}
		catch (Exception ex)
		{
			throw new Exception("error on get by id");
		}
	}
}