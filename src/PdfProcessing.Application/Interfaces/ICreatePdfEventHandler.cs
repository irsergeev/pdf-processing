using PdfProcessing.Infrastructure.Integration.Contracts.Events;

namespace PdfProcessing.Application.Interfaces;

public interface ICreatePdfEventHandler
{
    Task HandleAsync (CreatePdfEvent eventData, CancellationToken cancellationToken);
}
