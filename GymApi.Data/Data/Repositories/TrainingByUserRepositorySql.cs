using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class TrainingByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, TrainingUser>, ITrainingByUserRepositorySql
{
	private readonly ICreateUserRepositorySql _createUserRepository;
	private readonly IPlanRepositorySql _planRepositorySql;
    public TrainingByUserRepositorySql(GymDbContext context, ICreateUserRepositorySql createUserRepository, IPlanRepositorySql planRepositorySql) : base(context)
    {
	    _createUserRepository = createUserRepository;
	    _planRepositorySql = planRepositorySql;
    }

    public async Task<bool> CorrectDayOfTraining(Guid id)
    {
	    var user = await _createUserRepository.GetUserById(id.ToString());
	    var planUser = await _planRepositorySql.FindById(user.PlanId);
	    var dayInWeek = planUser.DayOfWeeks.Split(',');
	    return dayInWeek.Any(dayInPlan =>
		    string.Equals(
			    dayInPlan.Trim(),
			    Enum.GetName(DateTime.Today.DayOfWeek),
			    StringComparison.OrdinalIgnoreCase));
    }

}