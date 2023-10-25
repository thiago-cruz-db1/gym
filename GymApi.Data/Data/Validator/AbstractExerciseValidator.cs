using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;

namespace GymApi.Data.Data.Validator;

public class AbstractExerciseValidator : IValidatorExercise
{
	private readonly IValidatorExercise _validatorExercise;

	public AbstractExerciseValidator(IValidatorExercise validatorExercise)
	{
		_validatorExercise = validatorExercise;
	}

	public virtual bool DuplicateExercise(Exercise exercise)
	{
		return _validatorExercise.DuplicateExercise(exercise);
	}
}