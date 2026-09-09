namespace Section12_TicketsDataAggregator.OutputWriter;

internal interface IOutputWriter : IDisposable
{
    public void WriteLine(string line);
    public void WriteLines(IEnumerable<string> lines);
}