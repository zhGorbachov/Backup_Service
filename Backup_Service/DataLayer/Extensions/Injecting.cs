using DataLayer.Context;
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
    }
}