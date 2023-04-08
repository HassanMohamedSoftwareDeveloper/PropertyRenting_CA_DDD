using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyRenting.Application.Primitives;
using PropertyRenting.Infrastructure.Persistence.Constants;
using PropertyRenting.Infrastructure.Persistence.Contexts;
using PropertyRenting.Infrastructure.Persistence.Interceptors;
using PropertyRenting.Infrastructure.Persistence.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Repositories.Write;
using PropertyRenting.Infrastructure.Persistence.Services;
using Scrutor;
using System.Reflection;

namespace PropertyRenting.Infrastructure.Persistence;

public static class DependancyInjection
{
    #region Methods :
    public static IServiceCollection AddPersistence(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddInterceptors()
            .AddDbContext(configuration)
            .AddWriteRepositories()
            .AddUnitOfWorks()
            .AddServices()
            .AddReadRepositories()
            .AddQueries();
    }
    public static async Task MigrateDbContext(this IApplicationBuilder builder)
    {
        try
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var logger = scope.ServiceProvider.GetService<Serilog.ILogger>();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<PropertyRentingWriteContext>();
                logger.Information("Start apply migration...");
                await context.Database.MigrateAsync();
                logger.Information("Complete applying migration...");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to migrate database.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    #endregion

    #region Helpers :
    private static IServiceCollection AddDbContext(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddDbContext<PropertyRentingWriteContext>((sp, options) =>
        {
            var autidableInterceptor = sp.GetService<AutidableInterceptor>();
            options.UseSqlServer(configuration.GetConnectionString(ConnectionStringKeys.Write_DB_Connection_String_Key))
            .AddInterceptors(autidableInterceptor);
        })
        .AddDbContext<PropertyRentingReadContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString(ConnectionStringKeys.Read_DB_Connection_String_Key)));

        return @this;
    }
    private static IServiceCollection AddWriteRepositories(this IServiceCollection @this)
    {
        @this.Scan(scan =>
        scan.FromAssembliesOf(typeof(WriteRepository<>))
        .AddClasses(classes => classes.AssignableTo(typeof(WriteRepository<>)))
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return @this;
    }
    private static IServiceCollection AddReadRepositories(this IServiceCollection @this)
    {
        @this.Scan(scan =>
        scan.FromAssembliesOf(typeof(ReadRepository<>))
        .AddClasses(classes => classes.AssignableTo(typeof(ReadRepository<>)))
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return @this;
    }
    private static IServiceCollection AddUnitOfWorks(this IServiceCollection @this)
    {
        return @this.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    private static IServiceCollection AddServices(this IServiceCollection @this)
    {
        @this.Scan(scan =>
        scan.FromAssemblyOf<BaseReadSevice>()
        .AddClasses(classes => classes.AssignableTo<BaseReadSevice>())
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return @this;
    }
    private static IServiceCollection AddQueries(this IServiceCollection @this)
    {
        return @this.AddMediatR(Assembly.GetExecutingAssembly());
    }
    private static IServiceCollection AddInterceptors(this IServiceCollection @this)
    {
        return @this.AddSingleton<AutidableInterceptor>();
    }


    #endregion
}
