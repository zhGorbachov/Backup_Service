using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers;

public class BackupController : Controller
{
    private readonly IMapper _mapper;
    private readonly IBackupService _backupService;

    public BackupController(IBackupService backupService, IMapper mapper)
    {
        _backupService = backupService;
        _mapper = mapper;
    }

    [HttpPost("AddBackup")]
    public async Task<IActionResult> AddBackupModelAsync(BackupDTO backupDto)
    {
        var backupModel = _mapper.Map<BackupModel>(backupDto);
        var backup = await _backupService.AddBackupAsync(backupModel);
        return Ok(backup);
    }

    [HttpPut("UpdateBackup")]
    public async Task<IActionResult> UpdateBackupModelAsync(BackupDTO backupDto, int id)
    {
        var backupModel = _mapper.Map<BackupModel>(backupDto);
        var backup = await _backupService.UpdateBackupAsync(backupModel, id);
        return Ok(backup);
    }
    
    [HttpDelete("DeleteBackup")]
    public async Task<IActionResult> DeleteBackupModelAsync(int id)
    {
        await _backupService.DeleteBackupAsync(id);
        return Ok();
    }
    
    [HttpGet("GetAllBackups")]
    public IActionResult GetAllBackupsModel()
    {
        var backupModels = _backupService.GetAllBackups();
        var backupsDto = _mapper.ProjectTo<BackupDTO>(backupModels);
        return Ok(backupsDto);
    }
    
    [HttpGet("GetBackupById")]
    public async Task<IActionResult> GetBackupByIdAsync(int id)
    {
        var backupModel = await _backupService.GetBackupModelByIdAsync(id);
        var backupDto = _mapper.Map<BackupDTO>(backupModel);
        return Ok(backupDto);
    }
    
    [HttpGet("GetBackupsByIdStorage")]
    public IActionResult GetBackupsByIdStorage(int idStorage)
    {
        var backupModels = _backupService.GetBackupModelsByIdStorage(idStorage);
        var backupDto = _mapper.ProjectTo<BackupDTO>(backupModels);
        return Ok(backupDto);
    }
}