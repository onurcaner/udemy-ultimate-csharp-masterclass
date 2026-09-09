using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace Section12_TicketsDataAggregator.PdfReader;

internal class PdfTextReader : IPdfTextReader
{
    public IEnumerable<string> ReadFolder(string folderPath)
    {
        IEnumerable<string> pdfFilePaths = Directory.GetFiles(folderPath, "*.pdf", SearchOption.TopDirectoryOnly);
        return pdfFilePaths.Select(this.ReadOne);
    }

    public string ReadOne(string filePath)
    {
        using PdfDocument document = PdfDocument.Open(filePath);

        StringBuilder stringBuilder = new();
        foreach (Page page in document.GetPages())
        {
            stringBuilder.AppendLine(
                ContentOrderTextExtractor.GetText(page)
            );
        }

        return stringBuilder.ToString();
    }
}