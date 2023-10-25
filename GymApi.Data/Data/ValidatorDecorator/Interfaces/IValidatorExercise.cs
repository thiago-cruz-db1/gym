using GymApi.Domain;

namespace GymApi.Data.Data.ValidatorDecorator.Interfaces;

public interface IValidatorExercise
{
	public bool DuplicateExercise(Exercise exercise);
}