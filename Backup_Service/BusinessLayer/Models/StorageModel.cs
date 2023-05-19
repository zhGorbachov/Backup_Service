namespace BusinessLayer.Models;

public class StorageModel
{
    public string Path { get; set; }
    public decimal TotalSize { get; set; }
    public decimal UsedSize { get; set; }
}