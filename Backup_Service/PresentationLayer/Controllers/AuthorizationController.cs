using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using IAuthorizationService = BusinessLayer.Interfaces.IAuthorizationService;

namespace PresentationLayer.Controllers;


public class AuthorizationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IJWTService _jwtService;
    
    public AuthorizationController(IMapper mapper, IAuthorizationService authorizationService)
    {
        _mapper = mapper;
        _authorizationService = authorizationService;
    }

    public async Task<IActionResult> RegistrationPage()
    {
        return View();
    }
    
    public async Task<IActionResult> LoginPage()
    {
        return View();
    }
    
    [HttpPost("Registration")]
    public async Task<IActionResult> Registration(AccountDTO accountDto)
    {
        accountDto.IdStorage = 1;
        accountDto.TariffType = 1;
        accountDto.IdUser = 1;
        
        var accountModel = _mapper.Map<AccountModel>(accountDto);

        if (await _authorizationService.RegistrationAccountAsync(accountModel))
        {
            return Redirect("/Authorization/LoginPage");
        }
        
        return BadRequest("This username is not suitable!");
    }

    [HttpPost("token")]
    public async Task<IActionResult> Login(AccountDTO accountDto)
    {

        var accountModel = _mapper.Map<AccountModel>(accountDto);

        var token = await _authorizationService.LoginAccountAsync(accountModel);
        
        if (token == "")
        {
            return BadRequest("Account with it fills does not exist");
        }

        var request = new
        {
            bearer = token,
        };
        
        return Json(request);
    }

}