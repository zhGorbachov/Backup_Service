using DataLayer.Context;

namespace DataLayer.Extensions;

public class DbInitializer
{
    public static void Initialize(BackupContext context)
    {
        context.Database.EnsureCreated();
    }
}