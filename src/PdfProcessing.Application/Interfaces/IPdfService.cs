using PdfProcessing.Infrastructure.Persistence.Entities;
using PdfProcessing.Infrastructure.Persistence.Enums;

namespace PdfProcessing.Application.Interfaces;

public interface IPdfService
{
    Task CreateAsync(PdfDocument document);
    Task<PdfDocument> GetAsync(Guid id);
    Task<IReadOnlyList<PdfDocument>> GetListAsync();
    Task<string> GetStringContentAsync(Guid id);
    Task SetUploadingStatus(Guid id, UploadingStatusEnum status);
}
