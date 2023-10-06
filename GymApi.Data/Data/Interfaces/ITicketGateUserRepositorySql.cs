using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;
using GymApi.Domain.Enum;

namespace GymApi.Data.Data.Interfaces;

public interface ITicketGateUserRepositorySql : IBaseRepositorySql<Guid, TicketGateUser>
{
    Task<List<string>> GetAbleUsers(DateTime day);
}