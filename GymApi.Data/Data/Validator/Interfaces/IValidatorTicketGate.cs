namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorTicketGate
{
	public Task<List<string>> GetAbleUsersToTicketGate(DateTime day);
}