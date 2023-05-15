namespace DataLayer.DTO;

public class TariffDTO
{
    public int Id { get; set; }
    public string TariffName { get; set; }
    public decimal Price { get; set; }
    public decimal BackupSize { get; set; }
}