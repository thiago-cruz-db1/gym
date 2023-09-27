using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Domain;
using Microsoft.Extensions.Options;

namespace GymApi.Data.Data.PlanRepository;

public class ContractRepositoryNoSql : MongoRepositorySqlAbstract<string, Contract>, IContractRepositorySql
{
    public ContractRepositoryNoSql(IOptions<GymDatabaseSettings> gymDatabaseSettings) : base(gymDatabaseSettings)
    {
    }
}