namespace GymApi.UseCases.Interfaces;

public interface ITicketGate
{
    List<string> UpdateTicketGate();
    bool VerifyIfValid(string id);
}