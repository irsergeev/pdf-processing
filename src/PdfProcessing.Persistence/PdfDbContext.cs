using Microsoft.EntityFrameworkCore;

namespace PdfProcessing.Infrastructure.Persistence;

public class PdfDbContext (DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(PdfDbContext).Assembly);
}
