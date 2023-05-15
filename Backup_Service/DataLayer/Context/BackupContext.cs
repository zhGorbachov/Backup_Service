using DataLayer.Entities;
using DataLayer.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public class BackupContext : DbContext
{
    public BackupContext(DbContextOptions<BackupContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Backup> Backups { get; set; }
    public DbSet<Storage> Storages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new TariffConfiguration());
        modelBuilder.ApplyConfiguration(new BackupConfiguration());
        modelBuilder.ApplyConfiguration(new StorageConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}