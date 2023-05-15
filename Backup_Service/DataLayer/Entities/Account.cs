namespace DataLayer.Entities;

public class Account : BaseEntity
{
    public int IdUser { get; set; }
    public int IdStorage { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string TarrifType { get; set; }
    
    public virtual Tariff Tariff { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Backup>? Backups { get; set; }
    public virtual Storage? Storage { get; set; }
}