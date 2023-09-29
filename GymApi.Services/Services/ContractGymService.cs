using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymApi.UseCases.Services;

public class ContractGymService
{
    private readonly IContractRepositoryNoSql _contractRepositoryNoSql;

    public ContractGymService(
        IContractRepositoryNoSql contractRepositoryNoSql)
    {
        _contractRepositoryNoSql = contractRepositoryNoSql;
    }

    public async Task<List<Contract>> GetAsync() =>
        await _contractRepositoryNoSql.FindAll();

    public async Task<Contract?> GetAsync(string id) =>
        await _contractRepositoryNoSql.FindById(id);

    public async Task CreateAsync(Contract newContract) =>
        await _contractRepositoryNoSql.Save(newContract);

    public async Task UpdateAsync(string id, Contract updatedContract) =>
        await _contractRepositoryNoSql.Update(id, updatedContract);

    public async Task RemoveAsync(string id) {
        var contract = await _contractRepositoryNoSql.FindById(id);
        _contractRepositoryNoSql.Delete(id, contract);
    }
}