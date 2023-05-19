namespace DataLayer.Entities;

public class Backup : BaseEntity
{
    public int? IdStorage { get; set; }
    public int? TariffType { get; set; }
    public string Name { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.Now;
    public decimal Size { get; set; }

    public virtual Storage? Storage { get; set; }
    public virtual Account? Account { get; set; }
}