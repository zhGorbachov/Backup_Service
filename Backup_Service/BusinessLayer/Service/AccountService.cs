using System.Data.Entity;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _contextAccount;
    private readonly IMapper _mapper;
    public AccountService(IAccountRepository context, IMapper mapper) 
    {
        _contextAccount = context;
        _mapper = mapper;
    }

    public async Task<AccountModel> GetAccountModelByIdAsync(int id)
    {
        var account = await _contextAccount.GetByIdAsync(id);
        return _mapper.Map<AccountModel>(account);
        // Obratitsa k repo i poluchity otvet tipa
        // otvet korotiy poluchil - zamapity
    }

    public IQueryable<AccountModel> GetAccountModelsByTariffType(int idTariff)
    {
        var accounts = _contextAccount.GetAccountsByTariffType(idTariff);
        return _mapper.ProjectTo<AccountModel>(accounts);
    }

    public IQueryable<AccountModel> GetAccountModelsByUserId(int id)
    {
        var accounts = _contextAccount.GetAccountsByUserId(id);
        return _mapper.ProjectTo<AccountModel>(accounts);
    }

    public IQueryable<AccountModel> GetAccountModelsByStorageId(int idStorage)
    {
        var accounts = _contextAccount.GetAccountsByStorageId(idStorage);
        return _mapper.ProjectTo<AccountModel>(accounts);
    }
    
    public async Task<Account> AddAccountAsync(AccountModel accountModel)
    {
        var account = _mapper.Map<Account>(accountModel);
        return await _contextAccount.AddAsync(account);
    }

    public async Task<Account> UpdateAccountAsync(AccountModel accountModel, int id)
    {
        var account = _mapper.Map<Account>(accountModel);
        return await _contextAccount.UpdateAsync(account, id);
    }

    public async Task DeleteAccountAsync(int id)
    { 
        await _contextAccount.DeleteAsync(id);
    }

    public IQueryable<AccountModel> GetAllAccounts()
    {
        var accounts = _contextAccount.GetAll();
        return _mapper.ProjectTo<AccountModel>(accounts);
    }
}