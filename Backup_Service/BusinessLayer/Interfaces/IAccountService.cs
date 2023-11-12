using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Interfaces;

public interface IAccountService
{
    public Task<AccountModel> GetAccountModelByIdAsync(int id);
    public IQueryable<AccountModel> GetAccountModelsByTariffType(int idTariff);
    public IQueryable<AccountModel> GetAccountModelsByUserId(int id);
    public IQueryable<AccountModel> GetAccountModelsByStorageId(int idStorage);
    public int GetAccountModelIdByLogin(string Login);
    public Task<Account> AddAccountAsync(AccountModel accountModel);
    public Task<Account> UpdateAccountAsync(AccountModel accountModel, int id);
    public Task DeleteAccountAsync(int id);
    public IQueryable<AccountModel> GetAllAccounts();

}