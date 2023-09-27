using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.MySql;

namespace GymApi.Data.Data.PlanRepository;

public class TrainingByUserRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, TrainingByUserRepositorySql>
{
    public TrainingByUserRepositorySql(GymDbContext context) : base(context)
    {
    }
}