using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Persistence.Entities;

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

    public async Task UpdateStringContent(Guid id)
    {
        throw new NotImplementedException();
    }
}
