﻿using System.Data.Entity;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Service;

public class StorageService : IStorageService
{
    private readonly IStorageRepository _contextStorage;
    private readonly IMapper _mapper;
    public StorageService(IStorageRepository context, IMapper mapper) 
    {
        _contextStorage = context;
        _mapper = mapper;
    }

    public async Task<StorageModel> GetStorageModelByIdAsync(int id)
    {
        var storage = await _contextStorage.GetByIdAsync(id);
        // var storage = await _contextStorage.GetStorageByIdAsync(id);
        return _mapper.Map<StorageModel>(storage);
    }

    public async Task<Storage> AddStorageAsync(StorageModel storageModel)
    {
        var storage = _mapper.Map<Storage>(storageModel);
        return await _contextStorage.AddAsync(storage);
    }

    public async Task<Storage> UpdateStorageAsync(StorageModel storageModel, int id)
    {
        var storage = _mapper.Map<Storage>(storageModel);
        return await _contextStorage.UpdateAsync(storage, id);
    }

    public async Task DeleteStorageAsync(int id)
    {
        await _contextStorage.DeleteAsync(id);
    }

    public IQueryable<StorageModel> GetAllStorages()
    {
        var storages = _contextStorage.GetAll();
        return _mapper.ProjectTo<StorageModel>(storages);
    }
}