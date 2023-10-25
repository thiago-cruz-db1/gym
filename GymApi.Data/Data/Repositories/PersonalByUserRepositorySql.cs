using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Enum;

namespace GymApi.Data.Data.Repositories;

public class PersonalByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Domain.PersonalByUser>, IPersonalByUserRepositorySql
{
    private readonly GymDbContext _personalByUserRepositorySql;
    public PersonalByUserRepositorySql(GymDbContext context) : base(context)
    {
        _personalByUserRepositorySql = context;
    }

    public bool IsOpenToNewClient(PersonalByUser personalByUser)
    {
        var personalTrainerId = personalByUser.PersonalId;
        double totalMinutesConsumed = _personalByUserRepositorySql.PersonalByUsers
            .Where(e => e.StartAt.Date == personalByUser.StartAt.Date && e.PersonalId == personalTrainerId && e.IsActive)
            .Sum(e => e.DiffPersonalHours);
        return totalMinutesConsumed + personalByUser.DiffPersonalHours <
               (double)HoursDayPersonal.EightHours;
    }

    public bool IsDuplicateClientOnSameTime(PersonalByUser personalByUser)
    {
        var personalTrainerId = personalByUser.PersonalId;
        var personalByUsers =_personalByUserRepositorySql.PersonalByUsers
            .Where(e => e.IsActive && personalTrainerId == e.PersonalId)
            .ToList();
        bool isDuplicate = personalByUsers.Any(e =>
            (personalByUser.StartAt >= e.StartAt && personalByUser.StartAt < e.EndAt) ||
            (personalByUser.EndAt > e.StartAt && personalByUser.EndAt <= e.EndAt) ||
            (personalByUser.StartAt <= e.StartAt && personalByUser.EndAt >= e.EndAt)
        );
        return isDuplicate;
    }

    public bool IsDuplicatePersonalOnSameTime(PersonalByUser personalByUser)
    {
        var personalTrainerId = personalByUser.UserId;
        var personalByUsers =_personalByUserRepositorySql.PersonalByUsers
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