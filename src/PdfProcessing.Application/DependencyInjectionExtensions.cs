using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Application.Services;
using PdfProcessing.Application.Services.RabbitMQ.Consumers;
using PdfProcessing.Application.Settings;

namespace PdfProcessing.Application;

public static class DependencyInjectionExtensions
{
    public static T GetSectionOrThrow<T>(this IConfiguration configuration)
        => configuration.GetRequiredSection(nameof(T)).Get<T>()
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

                cfg.Host(rabbitSettings.HostName, h =>
                {
                    h.Username(rabbitSettings.Username);
                    h.Password(rabbitSettings.Password);
                });

                cfg.ReceiveEndpoint("create-pdf-queue", e =>
                {
                    e.ConfigureConsumer<CreatePdfEventConsumer>(context);
                });
            });
        });

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IPdfParser, IPdfParser>()
            .AddScoped<IPdfService, PdfService>()
            .AddAutoMapper(mapConfig =>
            {
                mapConfig.AddMaps(typeof(DependencyInjectionExtensions).Assembly);
            });

        return services;
    }
}
