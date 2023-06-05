using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers;

public class AccountController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public AccountController(IAccountService AccountService, IMapper mapper)
    {
        _accountService = AccountService;
        _mapper = mapper;
    }

    [HttpPost("AddAccount")]
    public async Task<IActionResult> AddAccountModelAsync(AccountDTO accountDto)
    {
        var accountModel = _mapper.Map<AccountModel>(accountDto);
        var account = await _accountService.AddAccountAsync(accountModel);
        return Ok(account);
    }

    [HttpPut("UpdateAccount")]
    public async Task<IActionResult> UpdateAccountModelAsync(AccountDTO accountDto, int id)
    {
        var accountModel = _mapper.Map<AccountModel>(accountDto);
        var account = await _accountService.UpdateAccountAsync(accountModel, id);
        return Ok(account);
    }
    
    [HttpDelete("DeleteAccount")]
    public async Task<IActionResult> DeleteAccountModelAsync(int id)
    {
        await _accountService.DeleteAccountAsync(id);
        return Ok();
    }
    
    [HttpGet("GetAllAccounts")]
    public IActionResult GetAllAccountsModel()
    {
        var accountModels = _accountService.GetAllAccounts();
        var accountsDto = _mapper.ProjectTo<AccountDTO>(accountModels);
        return Ok(accountsDto);
    }
    
    [HttpGet("GetAccountById")]
    public async Task<IActionResult> GetAccountByIdAsync(int id)
    {
        var accountModel = await _accountService.GetAccountModelByIdAsync(id);
        var accountDto = _mapper.Map<AccountDTO>(accountModel);
        return Ok(accountDto);
    }
    
    [HttpGet("GetAccountsByTariffType")]
    public IActionResult GetAccountsByTariffType(int typeTariff)
    {
        var accountModels = _accountService.GetAccountModelsByTariffType(typeTariff);
        var accountDto = _mapper.ProjectTo<AccountDTO>(accountModels);
        return Ok(accountDto);
    }
    
    [HttpGet("GetAccountsByUserId")]
    public IActionResult GetAccountsByUserId(int userId)
    {
        var accountModels = _accountService.GetAccountModelsByUserId(userId);
        var accountDto = _mapper.ProjectTo<AccountDTO>(accountModels);
        return Ok(accountDto);
    }
    
    [HttpGet("GetAccountByStorageId")]
    public IActionResult GetAccountByStorageId(int idStorage)
    {
        var accountModels = _accountService.GetAccountModelsByStorageId(idStorage);
        var accountDto = _mapper.ProjectTo<AccountDTO>(accountModels);
        return Ok(accountDto);
    }
}