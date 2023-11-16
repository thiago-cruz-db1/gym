using GymApi.Data.Data.Interfaces;

namespace GymApi.UseCases.Services.PlanHandler;

public class GetAllPlanCommandHandler
{
	private readonly IPlanRepositorySql _contextPlan;
	private readonly IPlanRepositoryCache _planRepositoryCache;

	public GetAllPlanCommandHandler(IPlanRepositorySql contextPlan, IPlanRepositoryCache planRepositoryCache)
	{
		_contextPlan = contextPlan;
		_planRepositoryCache = planRepositoryCache;
	}

	public async Task<List<Domain.Plan>?> HandleGetAll()
	{
		var SET_COLLECTION = "PLANS";
		try
		{
			var result = await _planRepositoryCache.GetCollection<Domain.Plan>(SET_COLLECTION);
			if (result is not null) return result;
			var plans = await _contextPlan.FindAll();
			await _planRepositoryCache.SetCollection(SET_COLLECTION, plans);
			return plans;
		}
		catch (Exception ex)
		{
			throw new Exception("error on get all", ex);
		}
	}

}