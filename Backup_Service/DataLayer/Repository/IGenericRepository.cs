using DataLayer.Entities;

namespace DataLayer.Repository;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task DeleteAsync(int id);
    public IQueryable<TEntity> GetAll();
}