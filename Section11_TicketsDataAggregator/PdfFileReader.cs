using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace Section11_TicketsDataAggregator;

public class PdfFileReader
{
    public string Read(string filePath)
    {
        using PdfDocument document = PdfDocument.Open(filePath);

        StringBuilder stringBuilder = new();
        foreach (Page page in document.GetPages())
        {
            string text = ContentOrderTextExtractor.GetText(page);
            stringBuilder.AppendLine(text);
        }

        return stringBuilder.ToString();
    }
}