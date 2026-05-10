namespace PdfProcessing.Infrastructure.Persistence.Interfaces;

public interface IRepository<T> : IQueryable<T>
{
    void Create(T entity);
    void Create(IEnumerable<T> entities);
}
