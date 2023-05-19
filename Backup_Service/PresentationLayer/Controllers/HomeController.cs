using System.Data.Entity;
using System.Diagnostics;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAccountService _accountService;
    private readonly ITariffService _tariffService;

    public HomeController(ILogger<HomeController> logger, IAccountService accountService, ITariffService tariffService)
    {
        _logger = logger;
        _accountService = accountService;
        _tariffService = tariffService;
    }
    [HttpGet("Test")]
    public async Task<IActionResult> Index()
    {
        var accountModel = new AccountModel()
        {
            Login = "zhekagor",
            Password = "zhekagor",
            TariffType = 1,
        };

        var tariffModel = new TariffModel()
        {
            TariffName = "High",
            BackupSize = 123,
            Price = 5000
        };
        
        
        // await _tariffService.AddTariffAsync(tariffModel);
        // Console.WriteLine("200");
        // await _tariffService.GetTariffModelByIdAsync(1);
        // Console.WriteLine("200");
        var account = await _accountService.AddAccountAsync(accountModel);
        _accountService.GetAccountModelsByTariffType(1);
        // var accounts = _accountService.GetAllAccounts();
        return View();
    }

    public IActionResult SayHello()
    {
        return Content("hello");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}