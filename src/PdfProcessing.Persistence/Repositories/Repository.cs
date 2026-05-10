using Microsoft.EntityFrameworkCore;
using PdfProcessing.Infrastructure.Persistence.Interfaces;
using System.Collections;
using System.Linq.Expressions;

namespace PdfProcessing.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly DbContext _context;
    public Repository(DbContext context) => _context = context;

    public void Create(T entity) => _context.Set<T>().Add(entity);
    public void Create(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => Query().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Query().GetEnumerator();
    Type IQueryable.ElementType => Query().ElementType;
    Expression IQueryable.Expression => Query().Expression;
    IQueryProvider IQueryable.Provider => Query().Provider;

    private IQueryable<T> Query() => _context.Set<T>();
}
