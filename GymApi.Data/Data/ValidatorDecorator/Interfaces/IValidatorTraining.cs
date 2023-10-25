namespace GymApi.Data.Data.ValidatorDecorator.Interfaces;

public interface IValidatorTraining
{
	public bool ValidationIfExerciseExist(ICollection<Guid> exercisesId);
}