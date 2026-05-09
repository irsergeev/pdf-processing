using MassTransit;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;

namespace PdfProcessing.Application.Services.RabbitMQ.Consumers;

public class CreatePdfEventConsumer (ICreatePdfEventHandler handler) : IConsumer<CreatePdfEvent>
{
    private readonly ICreatePdfEventHandler _handler = handler;

    public async Task Consume(ConsumeContext<CreatePdfEvent> context)
    {
        try
        {
            await _handler.HandleAsync(context.Message, context.CancellationToken);
        }
        catch (Exception ex)
        {
            // to do something
        }
    }
}
