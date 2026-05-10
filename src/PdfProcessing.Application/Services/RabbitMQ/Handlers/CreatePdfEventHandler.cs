using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;
using PdfProcessing.Infrastructure.Persistence.Enums;

namespace PdfProcessing.Application.Services.RabbitMQ.Handlers;

public class CreatePdfEventHandler (
    IPdfService pdfService,
    IPdfParser pdfParser
    ) : ICreatePdfEventHandler
{
    private readonly IPdfService _pdfService = pdfService;
    private readonly IPdfParser _pdfParser = pdfParser;

    public async Task HandleAsync(CreatePdfEvent eventData, CancellationToken cancellationToken)
    {
        if (eventData.DocumentContent == null || eventData.DocumentContent.Length == 0)
        {
            return;
        }

        try
        {
            var newPdfId = await _pdfService.CreateAsync();
            await _pdfService.SetUploadingStatus(newPdfId, UploadingStatusEnum.GETTING_TEXT);

            var pdfContentAsString = await _pdfParser.GetContentString(eventData.DocumentContent);

            await _pdfService.UpdateStringContent(newPdfId, pdfContentAsString);
            await _pdfService.SetUploadingStatus(newPdfId, UploadingStatusEnum.UPLOADED);
        }
        catch(Exception ex)
        {
            // to do something
        }
    }
}
