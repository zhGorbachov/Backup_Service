using DataLayer.Entities;

namespace Test.Data;

public static class RepositoryData
{
    public static IEnumerable<Storage> ExpectedStorages => 
        new List<Storage>
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

    public static IEnumerable<Backup> ExpectedBackups => 
        new List<Backup>
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
    
    public static IEnumerable<Account> ExpectedAccounts => 
        new List<Account>
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
    
    public static IEnumerable<User> ExpectedUsers => 
        new List<User>
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
    
    public static IEnumerable<Tariff> ExpectedTariffs => 
        new List<Tariff>
        {
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
}