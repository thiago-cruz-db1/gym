using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;

namespace GymApi.Data.Data.Repositories;

public class PersonalByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Domain.PersonalByUser>, IPersonalByUserRepositorySql
{
    public PersonalByUserRepositorySql(GymDbContext context) : base(context)
    {
    }
}