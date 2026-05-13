using PdfProcessing.API.Settings;
using PdfProcessing.Application.Interfaces;
using PdfProcessing.Application.Services;
using PdfProcessing.Infrastructure.Persistence;
using PdfProcessing.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IQueueUploadFileService, QueueUploadFileService>();

var databaseConnection = builder.Configuration.GetSectionOrThrow<DatabaseConnection>();
builder.Services.AddPersistenceRepository<PdfDbContext>(databaseConnection.PosgreSQL);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "pdf service");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();
