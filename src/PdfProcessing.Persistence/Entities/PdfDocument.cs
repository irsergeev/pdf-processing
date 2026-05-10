using PdfProcessing.Infrastructure.Persistence.Enums;

namespace PdfProcessing.Infrastructure.Persistence.Entities;

public class PdfDocument
{
    public Guid Id { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string DocumentContent { get; set; } = string.Empty;
    public UploadingStatusEnum ProcessingStatus { get; set; } = UploadingStatusEnum.NEW;
}
