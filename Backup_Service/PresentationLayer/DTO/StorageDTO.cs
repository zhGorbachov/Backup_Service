namespace DataLayer.DTO;

public class StorageDTO
{
    public int Id { get; set; }
    public string Path { get; set; }
    public decimal TotalSize { get; set; }
    public decimal UsedSize { get; set; }
}