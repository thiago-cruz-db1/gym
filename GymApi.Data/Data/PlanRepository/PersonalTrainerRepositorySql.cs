using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class PersonalTrainerRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, PersonalTrainer>, IPersonalTrainerRepositorySql
{
    public PersonalTrainerRepositorySql(GymDbContext context) : base(context)
    {
    }
}