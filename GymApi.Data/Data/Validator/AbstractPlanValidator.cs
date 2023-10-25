using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator;

public abstract class AbstractPlanValidator : IValidatorPlan
{
	private readonly IValidatorPlan _validatorPlan;

	public AbstractPlanValidator(IValidatorPlan validatorPlan)
	{
		_validatorPlan = validatorPlan;
	}

	public virtual async Task<bool> IsValidPlanName(string name)
	{
		return await _validatorPlan.IsValidPlanName(name);
	}
}