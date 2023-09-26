using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymApi.Data;

public interface IBaseRepository<TId, TEntity> where TEntity : class
{
    Task Save(TEntity entity);
    Task Update(TEntity entity);
    Task<ICollection<TEntity>> FindAll();
    Task<TEntity> FindById(TId id);
    void Delete(TEntity entity);
}