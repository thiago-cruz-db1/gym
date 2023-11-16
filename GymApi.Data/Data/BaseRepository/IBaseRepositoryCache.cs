namespace GymApi.Data.Data.BaseRepository;

public interface IBaseRepositoryCache
{
	Task<TEntity> GetValue<TEntity>(Guid id);
	Task<List<TEntity>?> GetCollection<TEntity>(string collectionKey);
	Task<bool> SetValue<TEntity>(string collectionKey, TEntity obj);
	Task<bool> SetCollection<TEntity>(string collectionKey, List<TEntity>? collection);
	public Task<bool> AddToCollection<TEntity>(string collectionKey, TEntity newItem);
}