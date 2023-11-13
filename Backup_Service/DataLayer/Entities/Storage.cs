namespace DataLayer.Entities;

public class Storage : BaseEntity
{
    public string Path { get; set; }
    public decimal TotalSize { get; set; }
    public decimal UsedSize { get; set; }

    public virtual ICollection<Backup>? Backups { get; set; }
    public virtual ICollection<Account>? Accounts { get; set; }
}
