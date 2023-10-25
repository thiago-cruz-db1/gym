using GymApi.Data.Data.MySql;
using GymApi.Data.Data.Validator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data.Data.Validator.Validators;

public class PlanValidator : IValidatorPlan
{
	private readonly GymDbContext _context;

	public PlanValidator(GymDbContext context)
	{
		_context = context;
	}

	public async Task<bool> IsValidPlanName(string name)
	{
		return await _context.Plans.AnyAsync(e => e.Category == name);
	}
}