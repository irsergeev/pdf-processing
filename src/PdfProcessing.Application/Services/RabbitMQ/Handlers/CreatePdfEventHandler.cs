using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;

namespace PdfProcessing.Application.Services.RabbitMQ.Handlers;

public class CreatePdfEventHandler (IPdfService pdfService) : ICreatePdfEventHandler
{
    private readonly IPdfService _pdfService = pdfService;

    public async Task HandleAsync(CreatePdfEvent eventData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
