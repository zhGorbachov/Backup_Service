namespace DataLayer.Entities;

public class  Tariff : BaseEntity
{
    public string TariffName { get; set; }
    public decimal Price { get; set; }
    public decimal BackupSize { get; set; }
    
    public virtual ICollection<Account>? Accounts { get; set; }
}