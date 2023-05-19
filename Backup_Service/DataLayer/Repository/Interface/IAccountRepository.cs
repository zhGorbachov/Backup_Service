using DataLayer.Entities;

namespace DataLayer.Repository.Interface;

public interface IAccountRepository : IGenericRepository<Account>
{
    // public Task<Account> GetAccountByIdAsync(int id);
    public IQueryable GetAccountsByTariffType(int idTariff);
    public IQueryable GetAccountsByUserId(int id);
    public IQueryable GetAccountsByStorageId(int idStorage);
}