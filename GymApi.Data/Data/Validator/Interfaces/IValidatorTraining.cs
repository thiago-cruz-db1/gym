namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorTraining
{
	public bool ValidationIfExerciseExist(ICollection<Guid> exercisesId);
}