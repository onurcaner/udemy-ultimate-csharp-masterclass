using Section11_TicketsDataAggregator.OutputWriter;
using Section11_TicketsDataAggregator.PdfReader;
using Section11_TicketsDataAggregator.TicketFormatter;
using Section11_TicketsDataAggregator.Tickets;
using Section11_TicketsDataAggregator.TicketsParser;

namespace Section11_TicketsDataAggregator;

internal class App
{
    private readonly string _folderPath;
    private readonly IOutputWriter _outputWriter;
    private readonly IPdfTextReader _pdfTextReader;
    private readonly ITicketFormatter _ticketFormatter;

    public App(
        string folderPath,
        IPdfTextReader pdfTextReader,
        IOutputWriter outputWriter,
        ITicketFormatter ticketFormatter)
    {
        this._folderPath = folderPath;
        this._pdfTextReader = pdfTextReader;
        this._outputWriter = outputWriter;
        this._ticketFormatter = ticketFormatter;
    }

    public void Execute()
    {
        // Read all .pdf 
        IEnumerable<string> ticketsPdfTexts = this._pdfTextReader.ReadFolder(this._folderPath);

        // Creating tickets query
        IEnumerable<ITicket> tickets = ticketsPdfTexts
            .Select(TicketsPdfTextParser.Parse)
            .SelectMany(ticket => ticket);

        // Write header
        this._outputWriter.WriteLine(
            this._ticketFormatter.CreateHeader()
        );

        // Write data
        IEnumerable<string> formattedTickets = tickets.Select(this._ticketFormatter.FormatTicket);
        foreach (string formattedLine in formattedTickets)
        {
            this._outputWriter.WriteLine(formattedLine);
        }
    }
}