namespace PdfProcessing.Infrastructure.Integration.Contracts.Events;

public class CreatePdfEvent
{
    public string ExternalId { get; set; } = string.Empty;
    public string DocumentContent { get; set; } = string.Empty;
}
