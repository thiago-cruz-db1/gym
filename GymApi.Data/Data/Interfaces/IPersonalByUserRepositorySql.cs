using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface IPersonalByUserRepositorySql : IBaseRepositorySql<Guid, PersonalByUser>
{
    public bool IsOpenToNewClient(PersonalByUser personalByUser);
    public bool IsDuplicateClientOnSameTime(PersonalByUser personalByUser);
    public bool IsDuplicatePersonalOnSameTime(PersonalByUser personalByUser);
}