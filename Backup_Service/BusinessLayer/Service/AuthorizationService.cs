using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Service;

public class AuthorizationService : IAuthorizationService
{
    private readonly IAccountService _accountService;
    // private readonly IMapper _mapper;
    private readonly IJWTService _jwtService;

    public AuthorizationService(IAccountService accountService, /*IMapper mapper,*/ IJWTService jwtService)
    {
        _accountService = accountService;
        // _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<bool> RegistrationAccountAsync(AccountModel accountModel)
    {
        var accountModelDB = await _accountService.GetAllAccounts().AnyAsync(x => x.Login == accountModel.Login);
        if (accountModelDB == false)
        {
            await _accountService.AddAccountAsync(accountModel);
            return true;
        }

        return false;
    }

    public async Task<string> LoginAccountAsync(AccountModel accountModel)
    {
        var accountModelDB = await _accountService.GetAllAccounts()
            .AnyAsync(x => x.Login == accountModel.Login && x.Password == accountModel.Password);

        if (accountModelDB)
        {
            var token = _jwtService.CreateJWTToken(accountModel);
            
            return token;
        }

        return "";
    }
}