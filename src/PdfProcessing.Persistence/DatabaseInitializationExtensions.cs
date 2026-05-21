using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PdfProcessing.Infrastructure.Persistence;

public static class DatabaseInitializationExtensions
{
    public static async Task EnsureDatabaseCreatedAsync(
        this IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
