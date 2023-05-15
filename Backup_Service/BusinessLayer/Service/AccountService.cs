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
    private readonly Mapper _mapper;
    public AccountService(IAccountRepository context, Mapper mapper) 
    {
        _contextAccount = context;
        _mapper = mapper;
    }

    public async Task<AccountModel> GetAccountModelByIdAsync(int id)
    {
        var account = await _contextAccount.GetAccountByIdAsync(id);
        return _mapper.Map<AccountModel>(account);
        // Obratitsa k repo i poluchity otvet tipa
        // otvet korotiy poluchil - zamapity
    }

    public IQueryable GetAccountModelsByTariffType(string tariff)
    {
        var accounts = _contextAccount.GetAccountsByTariffType(tariff);
        return _mapper.Map<IQueryable<AccountModel>>(accounts);
    }

    public IQueryable GetAccountModelsByUserId(int id)
    {
        var account = _contextAccount.GetAccountsByUserId(id);
        return _mapper.Map<IQueryable<AccountModel>>(account);
    }

    public IQueryable GetAccountModelsByStorageId(int idStorage)
    {
        var account = _contextAccount.GetAccountsByStorageId(idStorage);
        return _mapper.Map<IQueryable<AccountModel>>(account);
    }
    
    public async Task<Account> AddAccountAsync(AccountModel accountModel)
    {
        var account = _mapper.Map<Account>(accountModel);
        return await _contextAccount.AddAsync(account);
    }

    public async Task<Account> UpdateAccountAsync(AccountModel accountModel)
    {
        var account = _mapper.Map<Account>(accountModel);
        return await _contextAccount.UpdateAsync(account);
    }

    public async Task DeleteAccountAsync(int id)
    { 
        await _contextAccount.DeleteAsync(id);
    }

    public IQueryable GetAllAccounts()
    {
        var accounts = _contextAccount.GetAll();
        return _mapper.Map<IQueryable<AccountModel>>(accounts);;
    }
}