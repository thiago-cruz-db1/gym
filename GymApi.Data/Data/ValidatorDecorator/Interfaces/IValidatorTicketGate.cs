namespace GymApi.Data.Data.ValidatorDecorator.Interfaces;

public interface IValidatorTicketGate
{
	public Task<List<string>> GetAbleUsersToTicketGate(DateTime day);
}