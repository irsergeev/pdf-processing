using AutoMapper;
using PdfProcessing.Infrastructure.Integration.Contracts.Events;
using PdfProcessing.Infrastructure.Persistence.Entities;

namespace PdfProcessing.Application.Mapping;

public class PdfDocumentProfile : Profile
{
    public PdfDocumentProfile()
    {
        CreateMap<CreatePdfEvent, PdfDocument>();
    }
}
