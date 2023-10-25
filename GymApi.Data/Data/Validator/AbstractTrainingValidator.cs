using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator;

public class AbstractTrainingValidator : IValidatorTraining
{
	private readonly IValidatorTraining _validatorTraining;

	public AbstractTrainingValidator(IValidatorTraining validatorTraining)
	{
		_validatorTraining = validatorTraining;
	}

	public virtual bool ValidationIfExerciseExist(ICollection<Guid> exercisesId)
	{
		return _validatorTraining.ValidationIfExerciseExist(exercisesId);
	}
}