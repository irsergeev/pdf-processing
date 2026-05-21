using PdfProcessing.API.Middlewares;

namespace PdfProcessing.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UsePdfExceptionHandler(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlerMiddleware>();
}

