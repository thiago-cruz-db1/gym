using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator;

public class AbstractTrainingByUserValidator : IValidatorTrainingByUser
{
	private readonly IValidatorTrainingByUser _validatorTrainingByUser;

	public AbstractTrainingByUserValidator(IValidatorTrainingByUser validatorTrainingByUser)
	{
		_validatorTrainingByUser = validatorTrainingByUser;
	}

	public virtual Task<bool> CorrectDayOfTrainingByUserId(Guid id)
	{
		return _validatorTrainingByUser.CorrectDayOfTrainingByUserId(id);
	}
}