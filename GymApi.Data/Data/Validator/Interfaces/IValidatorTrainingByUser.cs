namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorTrainingByUser
{
	public Task<bool> CorrectDayOfTrainingByUserId(Guid id);
}