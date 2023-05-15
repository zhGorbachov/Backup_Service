using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace DataLayer.Repository.Class;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(BackupContext context) : base(context)
    {
        
    }

    public async Task<Account> GetAccountByIdAsync(int id)
    {
        var account = await GetAll().FirstAsync(x => x.Id == id);
        return account;
    }
    
    public IQueryable GetAccountsByTariffType(string tariff)
    {
        var accounts = GetAll().Where(x => x.TarrifType == tariff);
        
        return accounts;
    }

    public IQueryable GetAccountsByUserId(int id)
    {
        var accounts = GetAll().Where(x => x.IdUser == id);

        return accounts;
    }
    
    public IQueryable GetAccountsByStorageId(int idStorage)
    {
        var account = GetAll().Where(x => x.IdStorage == idStorage);

        return account;
    }
}