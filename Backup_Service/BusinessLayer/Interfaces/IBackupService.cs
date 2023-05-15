using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IBackupService
{
    public Task<BackupModel> GetBackupModelByIdAsync(int id);
    public IQueryable GetBackupModelsByIdStorage(int idStorage);
    public Task<Backup> AddBackupAsync(BackupModel backupModel);
    public Task<Backup> UpdateBackupAsync(BackupModel backupModel);
    public Task DeleteBackupAsync(int id);
    public IQueryable GetAllBackups();
}