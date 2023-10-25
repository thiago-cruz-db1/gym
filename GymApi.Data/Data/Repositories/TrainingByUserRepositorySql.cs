using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class TrainingByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, TrainingUser>, ITrainingByUserRepositorySql
{
    public TrainingByUserRepositorySql(GymDbContext context) : base(context)
    {
    }
}