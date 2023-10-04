using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface IPersonalTrainerRepositorySql : IBaseRepositorySql<Guid, PersonalTrainer>
{
    public List<PersonalByUser> GetUsersTraineeByDay(Guid id, DateTime date);
}