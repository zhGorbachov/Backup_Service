using Ionic.Zip;
using Ionic.Zlib;
using PresentationLayer.Controllers;
using PresentationLayer.DTO;

namespace PresentationLayer.Models;

public static class FileWorking
{
    private static void Compressing(string path, string pathCompressing)
    {
        if (File.Exists(pathCompressing))
        {
            File.Delete(pathCompressing);
        }
        using (var zip = new ZipFile())
        {
            
            zip.CompressionLevel =  CompressionLevel.Level6;
            zip.UseZip64WhenSaving = Zip64Option.Always;

            // zip.AddFile(path, "");
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                zip.AddDirectory(path, Path.GetFileName(path));
            
            else
            {
                zip.AddFile(path, "");
            }
            
            zip.Save(pathCompressing);
        }
        
        Directory.Delete(path, true);
    }

    public static void Uncompressing(string pathCompressing, string pathUncompressing)
    {
        using (var zip = ZipFile.Read(pathCompressing))
        {
            zip.ExtractAll(pathUncompressing);
        }
    }
    
    public static async Task<string> UploadFile(List<IFormFile> files, string username, int idBackup)
    {
        var currentDirectory = Path.Combine(Directory.GetCurrentDirectory(),"Backups\\");

        var uploadsFolder = Path.Combine(currentDirectory, "temp\\", username + "_" + idBackup);

        if (Directory.Exists(uploadsFolder))
            Directory.Delete(uploadsFolder, true);
        
        Directory.CreateDirectory(uploadsFolder);
        
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);
            await using(var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(stream);
            }
        }

        var zipPath = Path.Combine(currentDirectory,"Backups\\" , username + "_" + idBackup + ".zip");
        Compressing(uploadsFolder, zipPath);
        return zipPath;
    }
}