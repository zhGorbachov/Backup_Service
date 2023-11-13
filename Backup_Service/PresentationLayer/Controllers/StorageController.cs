using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers;

public class StorageController : Controller
{
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService, IMapper mapper)
    {
        _storageService = storageService;
        _mapper = mapper;
    }

    [HttpPost("AddStorage")]
    public async Task<IActionResult> AddStorageModelAsync(StorageDTO storageDto)
    {
        var storageModel = _mapper.Map<StorageModel>(storageDto);
        var storage = await _storageService.AddStorageAsync(storageModel);
        return Ok(storage);
    }

    [HttpPut("UpdateStorage")]
    public async Task<IActionResult> UpdateStorageModelAsync(StorageDTO storageDto, int id)
    {
        var storageModel = _mapper.Map<StorageModel>(storageDto);
        var storage = await _storageService.UpdateStorageAsync(storageModel, id);
        return Ok(storage);
    }
    
    [HttpDelete("DeleteStorage")]
    public async Task<IActionResult> DeleteStorageModelAsync(int id)
    {
        await _storageService.DeleteStorageAsync(id);
        return Ok();
    }
    
    [HttpGet("GetAllStorages")]
    public IActionResult GetAllStoragesModel()
    {
        var storageModels = _storageService.GetAllStorages();
        var storagesDto = _mapper.ProjectTo<StorageDTO>(storageModels);
        return Ok(storagesDto);
    }
    
    [HttpGet("GetStorageById")]
    public async Task<IActionResult> GetStorageByIdAsync(int id)
    {
        var storageModel = await _storageService.GetStorageModelByIdAsync(id);
        var storageDto = _mapper.Map<StorageDTO>(storageModel);
        return Ok(storageDto);
    }
}