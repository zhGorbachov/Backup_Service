using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext _context;
    
    public GenericRepository(DbContext context) 
    {
        _context = context;
    }
    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, int id)
    {
        entity.Id = id;
        var result = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable<TEntity> GetAll()
    {
        var entityList = _context.Set<TEntity>();
        return entityList;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return entity;
    }
}