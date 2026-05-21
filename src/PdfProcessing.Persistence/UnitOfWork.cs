using Microsoft.EntityFrameworkCore;
using PdfProcessing.Infrastructure.Persistence.Interfaces;

namespace PdfProcessing.Infrastructure.Persistence;

public class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    private readonly DbContext _dbContext = dbContext;

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
