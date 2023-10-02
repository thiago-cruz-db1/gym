namespace GymApi.UseCases.Interfaces;

public interface ITicketGate
{
    Task<List<string>> UpdateTicketGate();
    Task<bool> VerifyIfValid(string id);
}