using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class PlanRepository : BaseRepositoryAbstract<Guid, Plan>, IPlanRepository
{
    public PlanRepository(GymDbContext context) : base(context)
    {
    }
}