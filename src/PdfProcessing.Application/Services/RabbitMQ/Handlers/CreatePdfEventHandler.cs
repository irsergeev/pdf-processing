using AutoMapper;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;
using PdfProcessing.Infrastructure.Persistence.Entities;
using PdfProcessing.Infrastructure.Persistence.Enums;
using PdfProcessing.Infrastructure.Persistence.Interfaces;

namespace PdfProcessing.Application.Services.RabbitMQ.Handlers;

public class CreatePdfEventHandler (
    IPdfService pdfService,
    IPdfParser pdfParser,
    IMapper mapper,
    IUnitOfWork unitOfWork
    ) : ICreatePdfEventHandler
{
    private readonly IPdfService _pdfService = pdfService;
    private readonly IPdfParser _pdfParser = pdfParser;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(CreatePdfEvent eventData, CancellationToken cancellationToken)
    {
        if (eventData.DocumentContent == null || eventData.DocumentContent.Length == 0)
        {
            return;
        }

        try
        {
            var document = _mapper.Map<PdfDocument>(eventData);

            await _pdfService.CreateAsync(document);
            await _unitOfWork.SaveChangesAsync();

            await _pdfService.SetUploadingStatusAsync(document.Id, UploadingStatusEnum.GETTING_TEXT);

            var pdfContentAsString = await _pdfParser.GetContentString(eventData.DocumentContent);

            document.DocumentContent = pdfContentAsString;
            await _pdfService.SetUploadingStatusAsync(document.Id, UploadingStatusEnum.UPLOADED);

            await _unitOfWork.SaveChangesAsync();
        }
        catch
        {
        }
    }
}
