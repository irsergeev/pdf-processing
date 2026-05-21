using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Application.Parsers;
using PdfProcessing.Application.Services;
using PdfProcessing.Application.Services.RabbitMQ.Consumers;
using PdfProcessing.Application.Services.RabbitMQ.Handlers;
using PdfProcessing.Application.Settings;

namespace PdfProcessing.Application;

public static class DependencyInjectionExtensions
{
    public static T GetSectionOrThrow<T>(this IConfiguration configuration)
        => configuration.GetRequiredSection(typeof(T).Name).Get<T>()
            ?? throw new InvalidOperationException("Configuration item does not exists");

    public static IServiceCollection UseRabbitMqMasstransitConsumer(
           this IServiceCollection services,
           IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CreatePdfEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitSettings = configuration.GetSectionOrThrow<RabbitConsumerSetting>();
                ConfigureRabbitHost(cfg, rabbitSettings);

                if (string.IsNullOrWhiteSpace(rabbitSettings.QueueName))
                {
                    throw new ArgumentNullException("In settings queue name can not be empty");
                }

                cfg.ReceiveEndpoint(rabbitSettings.QueueName, e =>
                {
                    e.ConfigureConsumer<CreatePdfEventConsumer>(context);
                });
            });
        });

        return services;
    }

    public static IServiceCollection AddRabbitMqMassTransitPublisher(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((_, cfg) =>
            {
                var rabbitSettings = configuration.GetSectionOrThrow<RabbitConsumerSetting>();
                ConfigureRabbitHost(cfg, rabbitSettings);
            });
        });

        return services;
    }

    private static void ConfigureRabbitHost(IRabbitMqBusFactoryConfigurator cfg, RabbitConsumerSetting settings)
    {
        var port = ushort.TryParse(settings.Port, out var parsedPort) ? parsedPort : (ushort)5672;

        cfg.Host(settings.HostName, port, "/", h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IPdfParser, PdfParser>()
            .AddScoped<IPdfService, PdfService>()
            .AddScoped<ICreatePdfEventHandler, CreatePdfEventHandler>()
            .AddAutoMapper(mapConfig =>
            {
                mapConfig.AddMaps(typeof(DependencyInjectionExtensions).Assembly);
            });

        return services;
    }
}
