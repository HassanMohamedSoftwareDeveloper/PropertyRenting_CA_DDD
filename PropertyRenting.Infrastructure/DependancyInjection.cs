using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyRenting.Infrastructure.Behaviors;
using PropertyRenting.Infrastructure.Persistence;

namespace PropertyRenting.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddPersistence(configuration)
            .AddBehaviors();
    }

    private static IServiceCollection AddBehaviors(this IServiceCollection @this)
    {
        return @this
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}
