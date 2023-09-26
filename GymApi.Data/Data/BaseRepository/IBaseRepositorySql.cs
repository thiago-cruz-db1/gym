using GymApi.Domain;

namespace GymApi.Data.Data.BaseRepository;

public interface IBaseRepositorySql<TId, TEntity> where TEntity : class
{
    Task Save(TEntity entity);
    Task Update(TEntity entity);
    Task<List<TEntity>> FindAll();
    Task<TEntity> FindById(TId id);
    void Delete(TEntity entity);
}