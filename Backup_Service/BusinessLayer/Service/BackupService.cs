using System.Data.Entity;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Service;

public class BackupService : IBackupService
{
    private readonly IBackupRepository _contextBackup;
    private readonly Mapper _mapper;
    public BackupService(IBackupRepository context, Mapper mapper) 
    {
        _contextBackup = context;
        _mapper = mapper;
    }

    public async Task<BackupModel> GetBackupModelByIdAsync(int id)
    {
        var backup = await _contextBackup.GetBackupByIdAsync(id);
        return _mapper.Map<BackupModel>(backup);
    }

    public IQueryable GetBackupModelsByIdStorage(int idStorage)
    {
        var backups = _contextBackup.GetBackupsByIdStorage(idStorage);
        return _mapper.Map<IQueryable<BackupModel>>(backups);
    }

    public async Task<Backup> AddBackupAsync(BackupModel backupModel)
    {
        var backup = _mapper.Map<Backup>(backupModel);
        return await _contextBackup.AddAsync(backup);
    }

    public async Task<Backup> UpdateBackupAsync(BackupModel backupModel)
    {
        var backup = _mapper.Map<Backup>(backupModel);
        return await _contextBackup.UpdateAsync(backup);
    }

    public async Task DeleteBackupAsync(int id)
    {
        await _contextBackup.DeleteAsync(id);
    }

    public IQueryable GetAllBackups()
    {
        var backups = _contextBackup.GetAll();
        return _mapper.Map<IQueryable<BackupModel>>(backups);
    }
}