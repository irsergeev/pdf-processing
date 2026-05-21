using PdfProcessing.API.Settings;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Application.Services;
using PdfProcessing.Infrastructure.Persistence;
using PdfProcessing.Application;
using PdfProcessing.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConsoleLogging();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IQueueUploadFileService, QueueUploadFileService>();
builder.Services.AddRabbitMqMassTransitPublisher(builder.Configuration);

var databaseConnection = builder.Configuration.GetSectionOrThrow<DatabaseConnection>();
builder.Services.AddPersistenceRepository<PdfDbContext>(databaseConnection.PosgreSQL);

var app = builder.Build();

await app.Services.EnsureDatabaseCreatedAsync();

app.UsePdfExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "pdf service");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();
