FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY PdfProcessing.API/PdfProcessing.API.csproj PdfProcessing.API/
COPY PdfProcessing.Application/PdfProcessing.Application.csproj PdfProcessing.Application/
COPY PdfProcessing.Infrastructure.Integration/PdfProcessing.Infrastructure.Integration.Contracts.csproj PdfProcessing.Infrastructure.Integration/
COPY PdfProcessing.Persistence/PdfProcessing.Infrastructure.Persistence.csproj PdfProcessing.Persistence/

RUN dotnet restore PdfProcessing.API/PdfProcessing.API.csproj

COPY . .
RUN dotnet publish PdfProcessing.API/PdfProcessing.API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "PdfProcessing.API.dll"]
