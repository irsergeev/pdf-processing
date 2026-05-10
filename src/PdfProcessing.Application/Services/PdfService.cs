using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Persistence.Entities;
using PdfProcessing.Infrastructure.Persistence.Enums;

namespace PdfProcessing.Application.Services;

public class PdfService : IPdfService
{
    public async Task<Guid> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PdfDocument> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Guid>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetStringContentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SetUploadingStatus(Guid id, UploadingStatusEnum status)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateStringContent(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStringContent(Guid id, string updatedContent)
    {
        throw new NotImplementedException();
    }
}
