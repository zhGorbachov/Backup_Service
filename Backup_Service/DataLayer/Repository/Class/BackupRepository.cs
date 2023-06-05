using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace DataLayer.Repository.Class;

public class BackupRepository : GenericRepository<Backup>, IBackupRepository
{
    public BackupRepository(BackupContext context) : base(context)
    {
        
    }

    // public async Task<Backup> GetBackupByIdAsync(int id)
    // {
    //     var backup = await GetByIdAsync(id);
    //     return backup;
    // }

    public IQueryable GetBackupsByIdStorage(int idStorage)
    {
        var backups = GetAll().Where(x => x.IdStorage == idStorage);
        return backups;
    }
}