using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.Repositories;

public class PersonalTrainerRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, PersonalTrainer>, IPersonalTrainerRepositorySql
{
    private readonly GymDbContext _context;
    public PersonalTrainerRepositorySql(GymDbContext context) : base(context)
    {
        _context = context;
    }

    public List<PersonalByUser> GetUsersTraineeByDay(Guid id, DateTime date)
    {
        return _context.PersonalByUsers.Where(e => e.StartAt.Date == date.Date && e.PersonalId == id).ToList();
    }
}