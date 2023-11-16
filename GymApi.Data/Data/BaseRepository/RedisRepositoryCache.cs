using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GymApi.Data.Data.BaseRepository;

public class RedisRepositoryCache : IBaseRepositoryCache
{
	private readonly IDistributedCache _distributedCache;
	private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;
	public RedisRepositoryCache(IDistributedCache distributedCache)
	{
		_distributedCache = distributedCache;
		_distributedCacheEntryOptions = new DistributedCacheEntryOptions
		{
			AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60),
		};
	}

	public async Task<TEntity> GetValue<TEntity>(Guid id)
	{
		var key = id.ToString().ToLower();
		var result = await _distributedCache.GetStringAsync(key);
		return (result is null ? default :
			JsonConvert.DeserializeObject<TEntity>(result)) ?? throw new Exception("same error in cache happen");
	}

	public async Task<List<TEntity>?> GetCollection<TEntity>(string collectionKey)
	{
		var result = await _distributedCache.GetStringAsync(collectionKey);
		if (result is not null)
			return JsonConvert.DeserializeObject<List<TEntity>>(result);
		return null;
	}

	public async Task<bool> SetValue<TEntity>(string collectionKey, TEntity obj)
	{
		var serializedObj = JsonConvert.SerializeObject(obj);
		await _distributedCache.SetStringAsync(collectionKey, serializedObj, _distributedCacheEntryOptions);
		return true;
	}

	public async Task<bool> SetCollection<TEntity>(string collectionKey, List<TEntity>? collection)
	{
		var serializedCollection = JsonConvert.SerializeObject(collection);
		await _distributedCache.SetStringAsync(collectionKey, serializedCollection, _distributedCacheEntryOptions);
		return true;
	}

	public async Task<bool> AddToCollection<TEntity>(string collectionKey, TEntity newItem)
	{
		var existingCollection = await _distributedCache.GetStringAsync(collectionKey);
		var collection = new List<TEntity>();

		if (existingCollection is not null)
		{
			collection = JsonConvert.DeserializeObject<List<TEntity>>(existingCollection);
		}

		collection.Add(newItem);

		var serializedCollection = JsonConvert.SerializeObject(collection);
		await _distributedCache.SetStringAsync(collectionKey, serializedCollection);

		return true;
	}
}