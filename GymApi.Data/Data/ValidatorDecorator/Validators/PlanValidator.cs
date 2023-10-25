using GymApi.Data.Data.MySql;
using GymApi.Data.Data.ValidatorDecorator.Interfaces;

namespace GymApi.Data.Data.ValidatorDecorator.Validators;

public class PlanValidator : IValidatorPlan
{
	private readonly GymDbContext _context;

	public PlanValidator(GymDbContext context)
	{
		_context = context;
	}

	public bool IsValidPlanName(string name)
	{
		var isDuplicate = _context.Plans.Any(e => e.Category == name);
		return isDuplicate;
	}
}