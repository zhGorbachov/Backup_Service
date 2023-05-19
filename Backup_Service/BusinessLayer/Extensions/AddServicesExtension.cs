using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Extensions;

public static class AddServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        // services.AddScoped<IGenericRepository, GenericRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IBackupService, BackupService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITariffService, TariffService>();
        
    }
    
}