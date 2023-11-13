using DataLayer.Entities;

namespace DataLayer.Repository.Interface;

public interface ITariffRepository : IGenericRepository<Tariff>
{
    // public Task<Tariff> GetTariffByIdAsync(int id);
}