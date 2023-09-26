using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymApi.UseCases.Services;

public class ContractGymService
{
    private readonly IContractRepositorySql _contractRepositorySql;

    public ContractGymService(
        IContractRepositorySql contractRepositorySql)
    {
        _contractRepositorySql = contractRepositorySql;
    }

    public async Task<List<Contract>> GetAsync() =>
        await _contractRepositorySql.FindAll();

    public async Task<Contract?> GetAsync(string id) =>
        await _contractRepositorySql.FindById(id);

    public async Task CreateAsync(Contract newContract) =>
        await _contractRepositorySql.Save(newContract);

    public async Task UpdateAsync(string id, Contract updatedContract) =>
        await _contractRepositorySql.Update(id, updatedContract);

    public async Task RemoveAsync(string id) {
        var contract = await _contractRepositorySql.FindById(id);
        _contractRepositorySql.Delete(id, contract);
    }
}