namespace GymApi.Data.Data.ValidatorDecorator.Interfaces;

public interface IValidatorTrainingByUser
{
	public Task<bool> CorrectDayOfTrainingByUserId(Guid id);
}