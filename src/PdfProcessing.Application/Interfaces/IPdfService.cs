using PdfProcessing.Infrastructure.Persistence.Entities;

namespace PdfProcessing.Application.Interfaces;

public interface IPdfService
{
    Task<Guid> CreateAsync();
    Task UpdateStringContent(Guid id);
    Task<PdfDocument> GetAsync(Guid id);
    Task<IEnumerable<Guid>> GetListAsync();
    Task<string> GetStringContentAsync(Guid id);
}
