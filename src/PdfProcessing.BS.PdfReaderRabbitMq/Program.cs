using PdfProcessing.Application;
using PdfProcessing.BS.PdfReaderRabbitMq.Extensions;
using PdfProcessing.BS.PdfReaderRabbitMq.Settings;
using PdfProcessing.Infrastructure.Persistence;

var builder = Host.CreateApplicationBuilder(args);

builder.AddConsoleLogging();

var databaseConnection = builder.Configuration.GetSectionOrThrow<DatabaseConnection>();
builder.Services.AddPersistenceRepository<PdfDbContext>(databaseConnection.PosgreSQL);

builder.Services.AddApplication();
builder.Services.UseRabbitMqMasstransitConsumer(builder.Configuration);

var host = builder.Build();

await host.Services.EnsureDatabaseCreatedAsync();

await host.RunAsync();
