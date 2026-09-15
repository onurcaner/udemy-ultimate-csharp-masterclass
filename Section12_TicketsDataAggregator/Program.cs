using Section12_TicketsDataAggregator.OutputWriter;
using Section12_TicketsDataAggregator.PdfReader;
using Section12_TicketsDataAggregator.TicketFormatter;

namespace Section12_TicketsDataAggregator;

internal static class Program
{
    private const string FolderPath = "ticket_files";
    private const string OutputTextFileName = "tickets.txt";
    private const string OutputCsvFileName = "tickets.csv";

    private static void Main()
    {
        if (true)
        {
            string txtOutputPath = Path.Combine(Program.FolderPath, Program.OutputTextFileName);
            using OutputFileWriter txtOutputFileWriter = new(txtOutputPath);
            new App(
                pdfTextReader: new PdfTextReader(),
                folderPath: Program.FolderPath,
                outputWriter: txtOutputFileWriter,
                ticketFormatter: new TicketTextualFormatter()
            ).Execute();
            Console.WriteLine($"Tickets data saved to {txtOutputPath}");
        }

        if (true)
        {
            string csvOutputPath = Path.Combine(Program.FolderPath, Program.OutputCsvFileName);
            using OutputFileWriter csvOutputFileWriter = new(csvOutputPath);
            new App(
                pdfTextReader: new PdfTextReader(),
                folderPath: Program.FolderPath,
                outputWriter: csvOutputFileWriter,
                ticketFormatter: new TicketCsvFormatter()
            ).Execute();
            Console.WriteLine($"Tickets data saved to {csvOutputPath}");
        }


        Console.WriteLine();
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}