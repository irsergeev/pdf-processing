FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY PdfProcessing.BS.PdfReaderRabbitMq/PdfProcessing.BS.PdfReaderRabbitMq.csproj PdfProcessing.BS.PdfReaderRabbitMq/
COPY PdfProcessing.Application/PdfProcessing.Application.csproj PdfProcessing.Application/
COPY PdfProcessing.Infrastructure.Integration/PdfProcessing.Infrastructure.Integration.Contracts.csproj PdfProcessing.Infrastructure.Integration/
COPY PdfProcessing.Persistence/PdfProcessing.Infrastructure.Persistence.csproj PdfProcessing.Persistence/

RUN dotnet restore PdfProcessing.BS.PdfReaderRabbitMq/PdfProcessing.BS.PdfReaderRabbitMq.csproj

COPY . .
RUN dotnet publish PdfProcessing.BS.PdfReaderRabbitMq/PdfProcessing.BS.PdfReaderRabbitMq.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PdfProcessing.BS.PdfReaderRabbitMq.dll"]
