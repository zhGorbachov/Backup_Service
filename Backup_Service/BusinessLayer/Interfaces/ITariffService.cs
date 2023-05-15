using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface ITariffService
{
    public Task<TariffModel> GetTariffModelByIdAsync(int id);
    public Task<Tariff> AddTariffAsync(TariffModel tariffModel);
    public Task<Tariff> UpdateTariffAsync(TariffModel tariffModel);
    public Task DeleteTariffAsync(int id);
    public IQueryable GetAllTariffs();
}