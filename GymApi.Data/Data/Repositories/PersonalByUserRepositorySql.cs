using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Enum;

namespace GymApi.Data.Data.Repositories;

public class PersonalByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, PersonalByUser>, IPersonalByUserRepositorySql
{
    public PersonalByUserRepositorySql(GymDbContext context) : base(context)
    {

    }
}