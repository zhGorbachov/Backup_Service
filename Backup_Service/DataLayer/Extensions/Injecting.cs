using DataLayer.Context;
using DataLayer.Repository.Class;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Extensions;

public static class Injecting
{
    public static void Inject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BackupContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionString"]);
        });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<ITariffRepository, TariffRepository>();
        services.AddScoped<IBackupRepository, BackupRepository>();
    }
}