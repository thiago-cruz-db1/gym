using GymApi.Data.Data.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GymApi.Data.Data.BaseRepository;

public abstract class MongoRepositoryNoSqlAbstract<TId, TEntity> : IBaseRepositoryNoSql<TId, TEntity> where TEntity : class
{
    private IMongoCollection<TEntity> _gymsCollection;

    public MongoRepositoryNoSqlAbstract(IOptions<GymDatabaseSettings> gymDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            gymDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            gymDatabaseSettings.Value.DatabaseName);

        _gymsCollection = mongoDatabase.GetCollection<TEntity>(
            gymDatabaseSettings.Value.GymCollectionName);
    }
    public Task Save(TEntity entity)
    {
        return _gymsCollection.InsertOneAsync(entity);
    }

    public Task Update(TId id, TEntity entity)
    { 
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        return _gymsCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task<List<TEntity>> FindAll()
    {
        return await _gymsCollection.Find(_ => true).ToListAsync();
    }

    public Task<TEntity> FindById(TId id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        return _gymsCollection.Find(filter).FirstOrDefaultAsync();
    }

    public void Delete(TId id, TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        _gymsCollection.DeleteOneAsync(filter);
    }
}