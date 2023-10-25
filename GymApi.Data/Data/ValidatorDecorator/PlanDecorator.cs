using GymApi.Data.Data.ValidatorDecorator.Interfaces;

namespace GymApi.Data.Data.ValidatorDecorator;

public abstract class PlanDecorator : IValidatorPlan
{
	private readonly IValidatorPlan _validatorPlan;

	protected PlanDecorator(IValidatorPlan validatorPlan)
	{
		_validatorPlan = validatorPlan;
	}

	public virtual bool IsValidPlanName(string name)
	{
		return _validatorPlan.IsValidPlanName(name);
	}
}