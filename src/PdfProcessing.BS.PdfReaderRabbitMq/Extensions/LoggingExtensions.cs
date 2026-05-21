namespace PdfProcessing.BS.PdfReaderRabbitMq.Extensions;

public static class LoggingExtensions
{
    public static HostApplicationBuilder AddConsoleLogging(this HostApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

        return builder;
    }
}
