using GymApi.Data.Data.MySql;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;

namespace GymApi.Data.Data.Validator.Validators;

public class ExerciseValidator : IValidatorExercise
{
	private readonly GymDbContext _context;

	public ExerciseValidator(GymDbContext context)
	{
		_context = context;
	}

	public bool DuplicateExercise(Exercise exercise)
	{
		return _context.Exercises.Any(e =>
			e.Machine == exercise.Machine &&
			e.Pause == exercise.Pause &&
			e.Set == exercise.Set &&
			e.Repetition == exercise.Repetition);
	}
}