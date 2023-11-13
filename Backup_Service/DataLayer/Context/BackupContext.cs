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
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Name = "Sobaka",
                    Surname = "Sob",
                    Email = "zzz",
                    PhoneNumber = "123"
                },
                new User
                {
                    Id = 2,
                    Name = "Cot",
                    Surname = "Co",
                    Email = "zzz",
                    PhoneNumber = "123"
                });
        
        modelBuilder.Entity<Tariff>()
            .HasData(
                new Tariff
                {
                    Id = 1,
                    TariffName = "Normal",
                    BackupSize = 100,
                    Price = 15,
                },
                new Tariff
                {
                    Id = 2,
                    TariffName = "Pozer",
                    BackupSize = 50,
                    Price = 3,
                });
        
        modelBuilder.Entity<Storage>()
            .HasData(
                new Storage
                {
                    Id = 1,
                    Path = "asd",
                    TotalSize = 50,
                    UsedSize = 15
                },
                new Storage
                {
                    Id = 2,
                    Path = "zxczxc",
                    TotalSize = 2222,
                    UsedSize = 123
                });
        
        modelBuilder.Entity<Account>()
            .HasData(
                new Account
                {
                    Id = 1,
                    IdUser = 1,
                    Login = "Sobaka",
                    Password = "Sob",
                    TariffType = 1,
                    IdStorage = 1
                },
                new Account
                {
                    Id = 2,
                    IdUser = 2,
                    Login = "Cot",
                    Password = "Co",
                    TariffType = 2,
                    IdStorage = 1
                });
        
        modelBuilder.Entity<Backup>()
            .HasData(
                new Backup
                {
                    Id = 1,
                    IdStorage = 1,
                    Name = "Sobaka123",
                    TariffType = 1,
                    CreationTime = DateTime.Now,
                    Size = 150,
                    IdAccount = 1
                },
                new Backup
                {
                    Id = 2,
                    IdStorage = 1,
                    Name = "Cot123",
                    TariffType = 1,
                    CreationTime = DateTime.Now,
                    Size = 150,
                    IdAccount = 2
                });
    }
}