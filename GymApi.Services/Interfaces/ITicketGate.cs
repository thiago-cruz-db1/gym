namespace GymApi.UseCases.Interfaces;

public interface ITicketGate
{
    Task<List<string>> UpdateTicketGate();
    bool VerifyIfValid(string id);
}