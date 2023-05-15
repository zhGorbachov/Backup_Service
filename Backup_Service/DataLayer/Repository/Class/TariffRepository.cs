using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace DataLayer.Repository.Class;

public class TariffRepository : GenericRepository<Tariff>, ITariffRepository
{
    public TariffRepository(BackupContext context) : base(context)
    {
        
    }

    public async Task<Tariff> GetTariffByIdAsync(int id)
    {
        var tariff = await GetAll().FirstAsync(x => x.Id == id);
        return tariff;
    }
}