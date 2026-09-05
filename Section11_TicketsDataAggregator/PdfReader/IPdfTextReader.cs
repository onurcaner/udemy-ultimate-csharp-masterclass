namespace Section11_TicketsDataAggregator.PdfReader;

internal interface IPdfTextReader
{
    public IEnumerable<string> ReadFolder(string folderPath);
    public string ReadOne(string filePath);
}