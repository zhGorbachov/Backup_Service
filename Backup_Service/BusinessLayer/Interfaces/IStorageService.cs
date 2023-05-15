using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IStorageService
{
    public Task<StorageModel> GetStorageModelByIdAsync(int id);
    public Task<Storage> AddStorageAsync(StorageModel storageModel);
    public Task<Storage> UpdateStorageAsync(StorageModel storageModel);
    public Task DeleteStorageAsync(int id);
    public IQueryable GetAllStorages();
}