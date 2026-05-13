using PdfProcessing.Application;
using PdfProcessing.BS.PdfReaderRabbitMq.Settings;
using PdfProcessing.Infrastructure.Persistence;

var builder = Host.CreateApplicationBuilder(args);

var databaseConnection = builder.Configuration.GetSectionOrThrow<DatabaseConnection>();
builder.Services.AddPersistenceRepository<PdfDbContext>(databaseConnection.PosgreSQL);

builder.Services.AddApplication();
builder.Services.UseRabbitMqMasstransitConsumer(builder.Configuration);

var host = builder.Build();
host.Run();
