using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace DataLayer.Repository.Class;

public class StorageRepository : GenericRepository<Storage>, IStorageRepository
{
    public StorageRepository(BackupContext context) : base(context)
    {
        
    }

    // public async Task<Storage> GetStorageByIdAsync(int id)
    // {
    //     var storage = await GetByIdAsync(id);
    //     return storage;
    // }
}