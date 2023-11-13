using DataLayer.Context;
using DataLayer.Entities;
using Microsoft;
using Microsoft.EntityFrameworkCore;

namespace Test;

internal static class UnitTestHelper
{
    public static DbContextOptions<BackupContext> GetUnitTestsDbOptions()
    {
        var options = new DbContextOptionsBuilder<BackupContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using (var context = new BackupContext(options))
        {
            SeedData(context);
        }
        
        return options;
    }

    public static void SeedData(BackupContext context)
    {
        var users = new List<User>
        {
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
            }
        };

        var accounts = new List<Account>
        {
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
            }
        };

        var backups = new List<Backup>
        {
            new Backup
            {
                Id = 1,
                IdStorage = 1,
                Name = "Sobaka123",
                TariffType = 1,
                CreationTime = DateTime.UtcNow,
                Size = 150,
                IdAccount = 1
            },
            new Backup
            {
                Id = 2,
                IdStorage = 1,
                Name = "Cot123",
                TariffType = 1,
                CreationTime = DateTime.UtcNow,
                Size = 150,
                IdAccount = 2
            }
        };

        var storages = new List<Storage>
        {
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
            }
        };

        var tariffs = new List<Tariff>{
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
                }
        };
        
        context.Users.AddRange(users);
        context.Accounts.AddRange(accounts);
        context.Backups.AddRange(backups);
        context.Storages.AddRange(storages);
        context.Tariffs.AddRange(tariffs);
        
        context.SaveChanges();
    }
}