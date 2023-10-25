using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.ValidatorDecorator.Interfaces;

namespace GymApi.Data.Data.ValidatorDecorator.Validators;

public class TrainingByUserValidator : IValidatorTrainingByUser
{
	private readonly IPlanRepositorySql _planRepositorySql;
	private readonly ICreateUserRepositorySql _createUserRepositorySql;

	protected TrainingByUserValidator(IPlanRepositorySql planRepositorySql, ICreateUserRepositorySql createUserRepositorySql)
	{
		_planRepositorySql = planRepositorySql;
		_createUserRepositorySql = createUserRepositorySql;
	}

	public async Task<bool> CorrectDayOfTrainingByUserId(Guid id)
	{
		var user = await _createUserRepositorySql.GetUserById(id.ToString());
		var planUser = await _planRepositorySql.FindById(user.PlanId);
		var dayInWeek = planUser.DayOfWeeks.Split(',');
		return dayInWeek.Any(dayInPlan =>
			string.Equals(
				dayInPlan.Trim(),
				System.Enum.GetName(DateTime.Today.DayOfWeek),
				StringComparison.OrdinalIgnoreCase));
	}
}