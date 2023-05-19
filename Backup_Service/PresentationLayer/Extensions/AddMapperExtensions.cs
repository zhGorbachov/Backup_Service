using PresentationLayer.Mapping;

namespace PresentationLayer.Extensions;

public static class AddMapperExtensions
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
    }
}