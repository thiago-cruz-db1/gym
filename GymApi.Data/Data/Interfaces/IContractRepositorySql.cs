using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface IContractRepositorySql : IBaseRepositoryNoSql<string, Contract>
{
    
}