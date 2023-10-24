using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Data.Migrations;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymApi.UseCases.Services;

public class ContractGymService
{
    private readonly IContractRepositoryNoSql _contractRepositoryNoSql;
    private readonly IMapper _mapper;

    public ContractGymService(
        IContractRepositoryNoSql contractRepositoryNoSql, IMapper mapper)
    {
	    _contractRepositoryNoSql = contractRepositoryNoSql;
	    _mapper = mapper;
    }

    public async Task<List<Contract>> GetAsync() =>
        await _contractRepositoryNoSql.FindAll();

    public async Task<Contract?> GetAsync(string id) =>
        await _contractRepositoryNoSql.FindById(id);

    public async Task CreateAsync(CreateContractRequest newContract)
    {
	    var contract = _mapper.Map<Contract>(newContract);
	    contract.Validate();
	    await _contractRepositoryNoSql.Save(contract);
    }

    public async Task UpdateAsync(string id, UpdateContractRequest updatedContract)
    {
	    var contract = _mapper.Map<Contract>(updatedContract);
	    contract.Validate();
	    await _contractRepositoryNoSql.Update(id, contract);
    }

    public async Task RemoveAsync(string id) {
        var contract = await _contractRepositoryNoSql.FindById(id);
        _contractRepositoryNoSql.Delete(id, contract);
    }
}