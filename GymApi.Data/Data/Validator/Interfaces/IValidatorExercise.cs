using GymApi.Domain;

namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorExercise
{
	public bool DuplicateExercise(Exercise exercise);
}