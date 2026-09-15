namespace Section12_TicketsDataAggregator.OutputWriter;

internal class OutputFileWriter : IOutputWriter
{
    private readonly StreamWriter _streamWriter;

    public OutputFileWriter(string filePath)
    {
        this._streamWriter = new StreamWriter(filePath, false);
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

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        this._streamWriter.Dispose();
    }
}