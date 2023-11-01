using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator.Validators;

public class TicketGateValidator : IValidatorTicketGate
{
	private readonly IPlanRepositorySql _planRepositorySql;
	private readonly ICreateUserRepositorySql _createUserRepositorySql;

	public TicketGateValidator(IPlanRepositorySql planRepositorySql, ICreateUserRepositorySql createUserRepositorySql)
	{
		_planRepositorySql = planRepositorySql;
		_createUserRepositorySql = createUserRepositorySql;
	}

	public async Task<List<string>> GetAbleUsersToTicketGate(DateTime day)
	{
		var allUsers = _createUserRepositorySql.GetUsers();
		var ableUsers = new List<string>();

		foreach (var user in allUsers)
		{
			var planByUser = await _planRepositorySql.FindById(user.PlanId);
			var dayInWeek = planByUser.DayOfWeeks.Split(',');

			if (dayInWeek.Any(dayInPlan =>
				    string.Equals(
					    dayInPlan.Trim(),
					    System.Enum.GetName(day.DayOfWeek),
					    StringComparison.OrdinalIgnoreCase)))
			{
				ableUsers.Add(user.Id);
			}
		}

		return ableUsers;
	}
}