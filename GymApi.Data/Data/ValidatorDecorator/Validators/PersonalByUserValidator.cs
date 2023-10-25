using GymApi.Data.Data.MySql;
using GymApi.Data.Data.ValidatorDecorator.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Enum;

namespace GymApi.Data.Data.ValidatorDecorator.Validators;

public class PersonalByUserValidator : IValidatorPersonalByUser
{
	private readonly GymDbContext _context;

	public PersonalByUserValidator(GymDbContext context)
	{
		_context = context;
	}

	public bool IsPeronalOpenToNewClient(PersonalByUser personalByUser)
	{
		var personalTrainerId = personalByUser.PersonalId;
		double totalMinutesConsumed = _context.PersonalByUsers
			.Where(e => e.StartAt.Date == personalByUser.StartAt.Date && e.PersonalId == personalTrainerId && e.IsActive)
			.Sum(e => e.DiffPersonalHours);
		return totalMinutesConsumed + personalByUser.DiffPersonalHours <
		       (double)HoursDayPersonal.EightHours;
	}

	public bool IsDuplicateClientOnSameTimeToPersonal(PersonalByUser personalByUser)
	{
		var personalTrainerId = personalByUser.PersonalId;
		var personalByUsers =_context.PersonalByUsers
			.Where(e => e.IsActive && personalTrainerId == e.PersonalId)
			.ToList();
		bool isDuplicate = personalByUsers.Any(e =>
			(personalByUser.StartAt >= e.StartAt && personalByUser.StartAt < e.EndAt) ||
			(personalByUser.EndAt > e.StartAt && personalByUser.EndAt <= e.EndAt) ||
			(personalByUser.StartAt <= e.StartAt && personalByUser.EndAt >= e.EndAt)
		);
		return isDuplicate;
	}

	public bool IsDuplicatePersonalOnSameTimeToClient(PersonalByUser personalByUser)
	{
		var personalTrainerId = personalByUser.UserId;
		var personalByUsers =_context.PersonalByUsers
			.Where(e => e.IsActive && personalTrainerId == e.UserId)
			.ToList();
		bool isDuplicate = personalByUsers.Any(e =>
			(personalByUser.StartAt >= e.StartAt && personalByUser.StartAt < e.EndAt) ||
			(personalByUser.EndAt > e.StartAt && personalByUser.EndAt <= e.EndAt) ||
			(personalByUser.StartAt <= e.StartAt && personalByUser.EndAt >= e.EndAt)
		);
		return isDuplicate;
	}
}