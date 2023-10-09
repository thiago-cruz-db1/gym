using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class ExerciseRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Exercise>, IExerciseRepositorySql
{
	private readonly GymDbContext _exerciseContext;
    public ExerciseRepositorySql(GymDbContext context) : base(context)
    {
	    _exerciseContext = context;
    }

    public bool DuplicateExercise(Exercise exercise)
    {
	    return _exerciseContext.Exercises.Any(e =>
		    e.Machine == exercise.Machine &&
		    e.Pause == exercise.Pause &&
		    e.Set == exercise.Set &&
		    e.Repetition == exercise.Repetition);
    }
}