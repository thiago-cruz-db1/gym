using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface ITrainingByUserRepositorySql : IBaseRepositorySql<Guid, TrainingUser>
{
  public Task<bool> CorrectDayOfTraining(Guid id);
}