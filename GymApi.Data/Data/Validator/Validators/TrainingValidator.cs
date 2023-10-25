using GymApi.Data.Data.MySql;
using GymApi.Data.Data.Validator.Interfaces;

namespace GymApi.Data.Data.Validator.Validators;

public class TrainingValidator : IValidatorTraining
{
	private readonly GymDbContext _context;

	public TrainingValidator(GymDbContext context)
	{
		_context = context;
	}

	public bool ValidationIfExerciseExist(ICollection<Guid> exercisesId)
	{
		var idsFromDataBase = _context.Exercises
			.Count(e => exercisesId.Contains(e.Id)) == exercisesId.Count;
		return idsFromDataBase;
	}
}