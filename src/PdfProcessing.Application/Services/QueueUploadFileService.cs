using MassTransit;
using Microsoft.AspNetCore.Http;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;

namespace PdfProcessing.Application.Services;

public class QueueUploadFileService(IPublishEndpoint publishEndpoint) : IQueueUploadFileService
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<bool> UploadPdfFileAsync(IFormFile uploadFile)
    {
        if (uploadFile == null || uploadFile.Length == 0)
        {
            return false;
        }

        try
        {
            using var memoryStream = new MemoryStream();
            await uploadFile.CopyToAsync(memoryStream);

            var messageModel = new CreatePdfEvent
            {
                ExternalId = Guid.NewGuid().ToString(),
                DocumentContent = memoryStream.ToArray()
            };

            await _publishEndpoint.Publish(messageModel);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
