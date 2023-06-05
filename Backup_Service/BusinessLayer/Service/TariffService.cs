using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Service;

public class TariffService : ITariffService
{
    private readonly ITariffRepository _contextTariff;
    private readonly IMapper _mapper;
    public TariffService(ITariffRepository context, IMapper mapper) 
    {
        _contextTariff = context;
        _mapper = mapper;
    }
    
    public async Task<TariffModel> GetTariffModelByIdAsync(int id)
    {
        var tariff = await _contextTariff.GetByIdAsync(id);
        return _mapper.Map<TariffModel>(tariff);
    }

    public async Task<Tariff> AddTariffAsync(TariffModel tariffModel)
    {
        var tariff = _mapper.Map<Tariff>(tariffModel);
        return await _contextTariff.AddAsync(tariff);
    }

    public async Task<Tariff> UpdateTariffAsync(TariffModel tariffModel, int id)
    {
        var tariff = _mapper.Map<Tariff>(tariffModel);
        return await _contextTariff.UpdateAsync(tariff, id);
    }

    public async Task DeleteTariffAsync(int id)
    {
        await _contextTariff.DeleteAsync(id);
    }

    public IQueryable<TariffModel> GetAllTariffs()
    {
        var tariffs = _contextTariff.GetAll();
        return _mapper.ProjectTo<TariffModel>(tariffs);
    }
}