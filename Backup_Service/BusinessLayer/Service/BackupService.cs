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
    private readonly IMapper _mapper;
    public BackupService(IBackupRepository context, IMapper mapper) 
    {
        _contextBackup = context;
        _mapper = mapper;
    }

    public async Task<BackupModel> GetBackupModelByIdAsync(int id)
    {
        var backup = await _contextBackup.GetByIdAsync(id);
        return _mapper.Map<BackupModel>(backup);
    }

    public IQueryable GetBackupModelsByIdStorage(int idStorage)
    {
        var backups = _contextBackup.GetBackupsByIdStorage(idStorage);
        return _mapper.ProjectTo<BackupModel>(backups);
    }

    public async Task<Backup> AddBackupAsync(BackupModel backupModel)
    {
        var backup = _mapper.Map<Backup>(backupModel);
        return await _contextBackup.AddAsync(backup);
    }

    public async Task<Backup> UpdateBackupAsync(BackupModel backupModel, int id)
    {
        var backup = _mapper.Map<Backup>(backupModel);
        return await _contextBackup.UpdateAsync(backup, id);
    }

    public async Task DeleteBackupAsync(int id)
    {
        await _contextBackup.DeleteAsync(id);
    }

    public IQueryable<BackupModel> GetAllBackups()
    {
        var backups = _contextBackup.GetAll();
        return _mapper.ProjectTo<BackupModel>(backups);
    }
}