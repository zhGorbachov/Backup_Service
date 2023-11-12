using System.Diagnostics;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PresentationLayer.DTO;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static string _path { get; set; }
    private List<string> _pathList; 
    private readonly IBackupService _backupService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IAccountService _accountService;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IMapper mapper,
        IBackupService backupService, IAccountService accountService)
    {
        _logger = logger;
        _hostEnvironment = webHostEnvironment;
        _backupService = backupService;
        _accountService = accountService;
        _mapper = mapper;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    [Authorize]
    public async Task<IActionResult> UploadingPage()
    {
        return View();
    }
    
    [Authorize]
    public async Task<IActionResult> DownloadingFilePage()
    {
        return View();
    }
    
    [HttpPost("UploadFiles"), Authorize]
    public async Task UploadFile(List<IFormFile> files)
    {
        Console.WriteLine("Length of file: " + files.Count());
        if (files.Count > 0 && files != null)
        {
            var backups = _backupService.GetAllBackups().Where(x => x.IdAccount == 1);
            var account = await _accountService.GetAccountModelByIdAsync(1);
            var name = "Backup_" + account.Login + "-" + backups.Count();
            
            var backupDTO = new BackupDTO
            {
                Name = name,
                IdStorage = 1,
                TariffType = 1,
                CreationTime = DateTime.UtcNow,
                Size = 0,
                IdAccount = 1   
            };
            var fileB = new FilePath()
            {
                filePath = await FileWorking.UploadFile(files, backupDTO),
            };

            backupDTO.Size = new FileInfo(fileB.filePath).Length;
            var backupModel = _mapper.Map<BackupModel>(backupDTO);
            await _backupService.AddBackupAsync(backupModel);
            _path = fileB.filePath;
            _pathList.Add(_path);
        }
    }

    [HttpGet("GetFile")]
    public async Task<IActionResult> DownloadFile()
    {
        Console.WriteLine(_path);
        var filePath = Path.Combine(_hostEnvironment.WebRootPath, _path);
        var fileName = Path.GetFileName(filePath);

        if (System.IO.File.Exists(filePath))
        {
            return PhysicalFile(filePath, GetMimeType(filePath), fileName);
        }
        Console.WriteLine(filePath);
        return NotFound();
    }
    
    private string GetMimeType(string fileName)
    {
        var provider = new FileExtensionContentTypeProvider();
        if (provider.TryGetContentType(fileName, out var contentType))
        {
            return contentType;
        }
    
        return "application/octet-stream";
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