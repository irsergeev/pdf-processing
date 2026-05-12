using Microsoft.AspNetCore.Http;

namespace PdfProcessing.Application.Interfaces;

public interface IQueueUploadFileService
{
    Task<bool> UploadPdfFileAsync(IFormFile uploadFile);
}
