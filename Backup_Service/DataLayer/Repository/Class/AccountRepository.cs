using System.Data.Entity;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Class;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(BackupContext context) : base(context)
    {
        
    }

    // public async Task<Account> GetAccountByIdAsync(int id)
    // {
    //     var account = await GetByIdAsync(id);
    //     return account;
    // }
    
    public IQueryable GetAccountsByTariffType(int idTariff)
    {
        var accounts = GetAll().Where(x => x.Id == idTariff);
        
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

    public int GetAccountIdByLogin(string Login)
    {
        var account = GetAll().First(x => x.Login == Login);
        
        return account.Id;
    }
}