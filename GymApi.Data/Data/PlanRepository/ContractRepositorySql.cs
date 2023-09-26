using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Domain;
using Microsoft.Extensions.Options;

namespace GymApi.Data.Data.PlanRepository;

public class ContractRepositorySql : MongoRepositorySqlAbstract<string, Contract>, IContractRepositorySql
{
    public ContractRepositorySql(IOptions<GymDatabaseSettings> gymDatabaseSettings) : base(gymDatabaseSettings)
    {
    }
}