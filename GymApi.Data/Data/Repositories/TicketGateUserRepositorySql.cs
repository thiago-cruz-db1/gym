using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Enum;

namespace GymApi.Data.Data.Repositories;

public class TicketGateUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, TicketGateUser>, ITicketGateUserRepositorySql
{
    private readonly IPlanRepositorySql _planRepositorySql;
    private readonly ICreateUserRepositorySql _createUserRepositorySql;
    public TicketGateUserRepositorySql(GymDbContext context, IPlanRepositorySql planRepositorySql, ICreateUserRepositorySql createUserRepositorySql) : base(context)
    {
        _planRepositorySql = planRepositorySql;
        _createUserRepositorySql = createUserRepositorySql;
    }

    // public async Task<bool> AbleToPass(Guid id, DateTime day)
    // {
    //     var user = await _createUserRepositorySql.GetUserById(id.ToString());
    //     var planByUser = await _planRepositorySql.FindById(user.PlanId);
    //     var dayInWeek = planByUser.DayOfWeeks.Split(',');
    //     return dayInWeek
    //         .Any(dayInPlan =>
    //         string.Equals(
    //             dayInPlan.Trim(), 
    //             Enum.GetName(day.DayOfWeek), 
    //             StringComparison.OrdinalIgnoreCase));
    // }

    public async Task<List<string>> GetAbleUsers(DateTime day)
    {
        var allUsers = _createUserRepositorySql.GetUsers(); 
        var ableUsers = new List<string>();

        foreach (var user in allUsers)
        {
            var planByUser = await _planRepositorySql.FindById(user.PlanId);
            var dayInWeek = planByUser.DayOfWeeks.Split(',');

            if (dayInWeek.Any(dayInPlan =>
                    string.Equals(
                        dayInPlan.Trim(),
                        Enum.GetName(day.DayOfWeek),
                        StringComparison.OrdinalIgnoreCase)))
            {
                ableUsers.Add(user.Id);
            }
        }

        return ableUsers;
    }
}