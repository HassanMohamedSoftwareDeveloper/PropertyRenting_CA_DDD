using FastEndpoints.Swagger;
using FluentValidation.AspNetCore;
using Mapster;
using PropertyRenting.Application;
using PropertyRenting.Infrastructure;
using System.Reflection;
using IMapper = MapsterMapper.IMapper;

namespace PropertyRenting.API;

public static class DependancyInjection
{
    #region Methods :
    public static IServiceCollection AddPresentation(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddFastEndpoints(options =>
            {
                options.IncludeAbstractValidators = true;
            })
            .AddInfrastructure(configuration)
            .AddApplication()
            .AddMappings()
            .AddValidations()
            .AddSwagger();
    }
    #endregion

    #region Helpers :
    private static IServiceCollection AddSwagger(this IServiceCollection @this)
    {
        return @this
             .AddSwaggerDoc(maxEndpointVersion: 1, addJWTBearerAuth: false, shortSchemaNames: true, settings: s =>
             {
                 s.DocumentName = "Release 1.0";
                 s.Title = "Property Renting Api";
                 s.Version = "v1.0";
             })
            ;
        //.AddEndpointsApiExplorer()
        //.AddSwaggerGen(options =>
        //{
        //    options.EnableAnnotations();
        //    options.SwaggerDoc("v1", new() { Title = $"API v1", Version = "v1" });
        //    options.SwaggerDoc("v2", new() { Title = $"API v2", Version = "v2" });
        //});
    }
    private static IServiceCollection AddMappings(this IServiceCollection @this)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        @this.AddSingleton(config);
        @this.AddScoped<IMapper, ServiceMapper>();
        return @this;
    }
    private static IServiceCollection AddValidations(this IServiceCollection @this)
    {

        return @this
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
    #endregion
}