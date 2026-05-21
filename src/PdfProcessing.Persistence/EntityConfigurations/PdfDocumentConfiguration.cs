using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfProcessing.Infrastructure.Persistence.Entities;

namespace PdfProcessing.Infrastructure.Persistence.EntityConfigurations;

public class PdfDocumentConfiguration : IEntityTypeConfiguration<PdfDocument>
{
    public void Configure(EntityTypeBuilder<PdfDocument> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
