using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PropertyRenting.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection @this)
    {
        return @this.AddMediatR(Assembly.GetExecutingAssembly())
            .AddMappings();
    }
    private static IServiceCollection AddMappings(this IServiceCollection @this)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        @this.AddSingleton(config);
        @this.AddScoped<IMapper, ServiceMapper>();
        return @this;
    }
}
