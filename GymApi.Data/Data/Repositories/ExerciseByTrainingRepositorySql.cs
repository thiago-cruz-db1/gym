using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class ExerciseByTrainingRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, ExerciseTraining>, IExerciseByTrainingRepositorySql
{
    public ExerciseByTrainingRepositorySql(GymDbContext context) : base(context)
    {
    }
}