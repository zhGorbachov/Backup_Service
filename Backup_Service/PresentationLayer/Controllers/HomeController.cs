using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static string _path { get; set; }
    private readonly IWebHostEnvironment _hostEnvironment;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _hostEnvironment = webHostEnvironment;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    
    public async Task<IActionResult> UploadingPage()
    {
        return View();
    }
    
    public async Task<IActionResult> DownloadingFilePage()
    {
        Console.WriteLine("FFAAA");
        Console.WriteLine(_path);
        return View();
    }
    
    // [Authorize]
    [HttpPost("UploadFiles")]
    public async Task<IActionResult> UploadFile(List<IFormFile> files)
    {
        Console.WriteLine(files.Count());
        if (files.Count > 0 && files != null)
        {
            Console.WriteLine("ASDASD");
            var fileB = new FilePath()
            {
                filePath = await FileWorking.UploadFile(files, "zhekagor", 1),
            };
            Console.WriteLine(fileB.filePath);
            _path = fileB.filePath;
            return RedirectToAction("DownloadingFilePage", "Home");
        }
        Console.WriteLine("GG");
        return Redirect("/Home");
    }

    [HttpGet("GetFile")]
    public async Task<IActionResult> DownloadFile()
    {
        Console.WriteLine(333);
        var filePath = Path.Combine(_hostEnvironment.WebRootPath, _path);
        Console.WriteLine(222);
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