using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class ExerciseRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, ExerciseTraining>, IExerciseRepositorySql
{
    public ExerciseRepositorySql(GymDbContext context) : base(context)
    {
    }
}