using GymApi.Data.Data.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymApi.Data.Data.BaseRepository;

public abstract class BaseRepositoryAbstract<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : class
{
    private GymDbContext _context;

    public BaseRepositoryAbstract(GymDbContext context)
    {
        _context = context;
    }

    public async Task Save(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<TEntity>> FindAll()
    {
        return (await _context.Set<TEntity>().ToListAsync())!;
    }

    public async Task<TEntity> FindById(TId id)
    {
        return (await _context.Set<TEntity>().FindAsync(id))!;
    }

    public async void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity!);
        await _context.SaveChangesAsync();
    }
}