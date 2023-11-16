using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace GymApi.Data.Data.Repositories;

public class PlanRepositoryCache : RedisRepositoryCache, IPlanRepositoryCache
{
	public PlanRepositoryCache(IDistributedCache distributedCache) : base(distributedCache)
	{
	}
}