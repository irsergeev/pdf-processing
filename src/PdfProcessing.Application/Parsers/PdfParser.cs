using PdfProcessing.Application.Interfaces;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace PdfProcessing.Application.Parsers;

public class PdfParser : IPdfParser
{
    public Task<string> GetContentString(byte[] pdfAsBytesArray)
    {
        var emptyStringResult = Task.FromResult(string.Empty);

        if (pdfAsBytesArray == null || pdfAsBytesArray.Length == 0)
        {
            return emptyStringResult;
        }

        try
        {
            using var pdfDocument = PdfDocument.Open(pdfAsBytesArray);

            foreach (var page in pdfDocument.GetPages())
            {
                var text = ContentOrderTextExtractor.GetText(page);
                IEnumerable<Word> words = page.GetWords(NearestNeighbourWordExtractor.Instance);

                var stringResult = string.Join(" ", words.Select(c => c.Text));
                return Task.FromResult(stringResult);
            }

            return emptyStringResult;
        }
        catch
        {
            return emptyStringResult;
        }
    }
}
