using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Interfaces;

public interface IAccountService
{
    public Task<AccountModel> GetAccountModelByIdAsync(int id);
    public IQueryable GetAccountModelsByTariffType(string tariff);
    public IQueryable GetAccountModelsByUserId(int id);
    public IQueryable GetAccountModelsByStorageId(int idStorage);
    public Task<Account> AddAccountAsync(AccountModel accountModel);
    public Task<Account> UpdateAccountAsync(AccountModel accountModel);
    public Task DeleteAccountAsync(int id);
    public IQueryable GetAllAccounts();

}