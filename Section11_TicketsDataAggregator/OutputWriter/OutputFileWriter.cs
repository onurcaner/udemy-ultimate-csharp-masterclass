namespace Section11_TicketsDataAggregator.OutputWriter;

internal class OutputFileWriter : IOutputWriter
{
    private readonly StreamWriter _streamWriter;

    public OutputFileWriter(string filePath)
    {
        this._streamWriter = new StreamWriter(filePath, false);
    }

    public void Dispose()
    {
        this._streamWriter.Dispose();
        GC.SuppressFinalize(this);
    }

    public void WriteLine(string line)
    {
        this._streamWriter.WriteLine(line);
    }

    public void WriteLines(IEnumerable<string> lines)
    {
        foreach (string line in lines)
        {
            this._streamWriter.WriteLine(line);
        }
    }
}