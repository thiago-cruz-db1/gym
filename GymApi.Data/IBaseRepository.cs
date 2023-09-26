namespace GymApi.Data;

public interface IBaseRepository<TId, TEntity>
{
    Task Create(TEntity entity);
    void Update(TId id, TEntity entity);
    Task Read();
    Task ReadById(TId id);
    void Delete(TId id);
}