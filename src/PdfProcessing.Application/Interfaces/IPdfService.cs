using PdfProcessing.Infrastructure.Persistence.Entities;
using PdfProcessing.Infrastructure.Persistence.Enums;

namespace PdfProcessing.Application.Interfaces;

public interface IPdfService
{
    Task<Guid> CreateAsync();
    Task UpdateStringContent(Guid id, string updatedContent);
    Task<PdfDocument> GetAsync(Guid id);
    Task<IEnumerable<Guid>> GetListAsync();
    Task<string> GetStringContentAsync(Guid id);
    Task SetUploadingStatus(Guid id, UploadingStatusEnum status);
}
