namespace PdfProcessing.API.Extensions;

public static class LoggingExtensions
{
    public static WebApplicationBuilder AddConsoleLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

        return builder;
    }
}
