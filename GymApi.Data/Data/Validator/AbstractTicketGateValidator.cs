using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator;

public class AbstractTicketGateValidator : IValidatorTicketGate
{
	private readonly IValidatorTicketGate _validatorTicketGate;

	public AbstractTicketGateValidator(IValidatorTicketGate validatorTicketGate)
	{
		_validatorTicketGate = validatorTicketGate;
	}

	public virtual Task<List<string>> GetAbleUsersToTicketGate(DateTime day)
	{
		return _validatorTicketGate.GetAbleUsersToTicketGate(day);
	}
}