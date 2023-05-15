using DataLayer.Entities;

namespace DataLayer.Repository.Interface;

public interface IBackupRepository : IGenericRepository<Backup>
{
    public Task<Backup> GetBackupByIdAsync(int id);
    public IQueryable GetBackupsByIdStorage(int idStorage);
}