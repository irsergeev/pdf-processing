using Microsoft.EntityFrameworkCore;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Persistence.Entities;
using PdfProcessing.Infrastructure.Persistence.Enums;
using PdfProcessing.Infrastructure.Persistence.Interfaces;

namespace PdfProcessing.Application.Services;

public class PdfService (IRepository<PdfDocument> repository) : IPdfService
{
    private readonly IRepository<PdfDocument> _repository = repository;

    public Task CreateAsync(PdfDocument document)
    {
        _repository.Create(document);
        return Task.CompletedTask;
    }

    public async Task<PdfDocument> GetAsync(Guid id)
    {
        var document = await _repository
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        return document!;
    }

    public async Task<IReadOnlyList<PdfDocument>> GetListAsync()
    {
        var documentList = new List<PdfDocument>();

        var documents = await _repository
            .AsNoTracking()
            .ToListAsync();

        documentList.AddRange(documents);
        return documentList;
    }

    public async Task<string> GetStringContentAsync(Guid id)
    {
        var document = await _repository.FirstOrDefaultAsync(c => c.Id == id);

        return document?.DocumentContent ?? string.Empty;
    }

    public async Task SetUploadingStatusAsync(Guid id, UploadingStatusEnum status)
    {
        await _repository
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.ProcessingStatus, status));
    }
}
