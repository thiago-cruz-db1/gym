using GymApi.Data.Data;
using GymApi.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymApi.UseCases.Services;

public class ContractGymService
{
    private readonly IMongoCollection<Contract> _gymsCollection;

    public ContractGymService(
        IOptions<GymDatabaseSettings> gymDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            gymDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            gymDatabaseSettings.Value.DatabaseName);

        _gymsCollection = mongoDatabase.GetCollection<Contract>(
            gymDatabaseSettings.Value.GymCollectionName);
    }

    public async Task<List<Contract>> GetAsync() =>
        await _gymsCollection.Find(_ => true).ToListAsync();

    public async Task<Contract?> GetAsync(string id) =>
        await _gymsCollection.Find(x => x.ContractId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Contract newContract) =>
        await _gymsCollection.InsertOneAsync(newContract);

    public async Task UpdateAsync(string id, Contract updatedContract) =>
        await _gymsCollection.ReplaceOneAsync(x => x.ContractId == id, updatedContract);

    public async Task RemoveAsync(string id) =>
        await _gymsCollection.DeleteOneAsync(x => x.ContractId == id);
}