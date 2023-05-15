using BusinessLayer.Interfaces;
using BusinessLayer.Service;
using DataLayer.Entities;
using DataLayer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Extensions;

public static class AddServicesExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddScoped<IGenericRepository, GenericRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IBackupService, BackupService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITariffService, TariffService>();
        
        Injecting.Inject(services, configuration);
    }
    
}