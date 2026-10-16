using Serilog;

namespace UnitConverter;

public static class ApplicationExtension
{
    public static void ConfigureSerilog(this IHostBuilder host)
    {
        host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.WriteTo.Console();
        });
    }
}
