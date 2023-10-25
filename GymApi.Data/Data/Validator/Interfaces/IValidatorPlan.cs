namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorPlan
{
	public Task<bool> IsValidPlanName(string name);
}