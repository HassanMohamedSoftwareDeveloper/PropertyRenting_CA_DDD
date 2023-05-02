using FastEndpoints.Swagger;
using PropertyRenting.API;
using PropertyRenting.Infrastructure.Persistence;
using Serilog;
using System.Text.Json;

Log.Logger = SeriLogHelper.CreateBootstrapLogger();

try
{
    Log.Information("starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.AddSeriLog();
    builder.Services.AddPresentation(builder.Configuration);


    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseFastEndpoints(options =>
    {
        options.Endpoints.ShortNames = true;
        options.Endpoints.RoutePrefix = "api";
        options.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.Versioning.Prefix = "v";
        options.Versioning.DefaultVersion = 1;
        options.Versioning.PrependToRoute = true;

    });
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerGen();
        //app.UseSwaggerUI(options =>
        //{
        //    //options.EnableTryItOutByDefault();
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        //    options.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
        //});
        //app.MapCSharpClientEndpoint("/cs-client", "version 1", s =>
        //{
        //    s.ClassName = "ApiClient";
        //    s.CSharpGeneratorSettings.Namespace = "My Namespace";
        //});

        //app.MapTypeScriptClientEndpoint("/ts-client", "version 1", s =>
        //{
        //    s.ClassName = "ApiClient";
        //    s.TypeScriptGeneratorSettings.Namespace = "My Namespace";
        //});
    }


    await app.MigrateDbContext();

    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
