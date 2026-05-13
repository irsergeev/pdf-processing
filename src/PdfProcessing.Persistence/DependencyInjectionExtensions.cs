using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PdfProcessing.Infrastructure.Persistence.Interfaces;
using PdfProcessing.Infrastructure.Persistence.Repositories;

namespace PdfProcessing.Infrastructure.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceRepository<TContext>(
        this IServiceCollection services,
        string connectionString)
        where TContext : DbContext
    {
        return services
            .AddScoped(_ => new DbContextOptionsBuilder()
                .UseNpgsql(connectionString)
                .Options)
            .AddScoped<DbContext, TContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
