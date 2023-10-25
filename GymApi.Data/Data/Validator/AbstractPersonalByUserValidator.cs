using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;

namespace GymApi.Data.Data.Validator;

public class AbstractPersonalByUserValidator : IValidatorPersonalByUser
{
	private readonly IValidatorPersonalByUser _validatorPersonalByUser;

	public AbstractPersonalByUserValidator(IValidatorPersonalByUser validatorPersonalByUser)
	{
		_validatorPersonalByUser = validatorPersonalByUser;
	}

	public virtual bool IsPersonalOpenToNewClient(PersonalByUser personalByUser)
	{
		return _validatorPersonalByUser.IsPersonalOpenToNewClient(personalByUser);
	}

	public virtual bool IsDuplicateClientOnSameTimeToPersonal(PersonalByUser personalByUser)
	{
		return _validatorPersonalByUser.IsDuplicateClientOnSameTimeToPersonal(personalByUser);
	}

	public virtual bool IsDuplicatePersonalOnSameTimeToClient(PersonalByUser personalByUser)
	{
		return _validatorPersonalByUser.IsDuplicatePersonalOnSameTimeToClient(personalByUser);
	}
}