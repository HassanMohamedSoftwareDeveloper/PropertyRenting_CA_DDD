using Serilog;

namespace PropertyRenting.API;

public static class SeriLogHelper
{
    public static Serilog.ILogger CreateBootstrapLogger()
    {
        var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        return new LoggerConfiguration().ReadFrom.Configuration(config).CreateBootstrapLogger();
    }
    public static void AddSeriLog(this WebApplicationBuilder @this)
    {
        @this.Host.UseSerilog((context, services, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services));
    }
}
