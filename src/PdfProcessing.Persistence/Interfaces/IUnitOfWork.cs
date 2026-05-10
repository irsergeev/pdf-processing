namespace PdfProcessing.Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
