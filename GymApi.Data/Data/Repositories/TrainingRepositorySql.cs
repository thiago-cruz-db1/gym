using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data.Data.Repositories;

public class TrainingRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Training>, ITrainingRepositorySql
{
    private readonly GymDbContext _contextExercise;
    public TrainingRepositorySql(GymDbContext context) : base(context)
    {
        _contextExercise = context;
    }

    public bool ValidationIfExerciseExist(ICollection<Guid> exercisesId)
    {
        var idsFromDataBase = _contextExercise.Exercises
            .Count(e => exercisesId.Contains(e.Id)) == exercisesId.Count;
        return idsFromDataBase;
    }

}