namespace DataLayer.Entities;

public class Backup : BaseEntity
{
    public int? IdStorage { get; set; }
    public int? TariffType { get; set; }
    public int? IdAccount { get; set; }
    public string Name { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal Size { get; set; }

    public virtual Storage? Storage { get; set; }
    public virtual Account? Account { get; set; }
}