using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class PlanRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Plan>, IPlanRepositorySql
{
	private GymDbContext _planRepositorySql;
    public PlanRepositorySql(GymDbContext context) : base(context)
    {
	    _planRepositorySql = context;
    }

    public bool IsValidName(string name)
    {
	    var isDuplicate = _planRepositorySql.Plans.Any(e => e.Category == name);
	    return !isDuplicate;
    }
}