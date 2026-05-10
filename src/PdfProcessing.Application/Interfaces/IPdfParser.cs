namespace PdfProcessing.Application.Interfaces;

public interface IPdfParser
{
    Task<string> GetContentString(byte[] pdfAsBytesArray);
}
