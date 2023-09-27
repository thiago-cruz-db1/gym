using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Domain;
using Microsoft.Extensions.Options;

namespace GymApi.Data.Data.Repositories;

public class ContractRepositoryNoNoSql : MongoRepositoryNoSqlAbstract<string, Contract>, IContractRepositoryNoSql
{
    public ContractRepositoryNoNoSql(IOptions<GymDatabaseSettings> gymDatabaseSettings) : base(gymDatabaseSettings)
    {
    }
}