using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class PlanRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Plan>, IPlanRepositorySql
{
    public PlanRepositorySql(GymDbContext context) : base(context)
    {
    }
}