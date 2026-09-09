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
        {
            string outputPath = Path.Combine(Program.FolderPath, Program.OutputTextFileName);
            using OutputFileWriter outputFileWriter = new(outputPath);

            new App(
                pdfTextReader: new PdfTextReader(),
                folderPath: Program.FolderPath,
                outputWriter: outputFileWriter,
                ticketFormatter: new TicketTextualFormatter()
            ).Execute();

            Console.WriteLine($"Tickets data saved to {outputPath}");
        }

        {
            string outputPath = Path.Combine(Program.FolderPath, Program.OutputCsvFileName);
            using OutputFileWriter csvOutputWriter = new(outputPath);

            new App(
                pdfTextReader: new PdfTextReader(),
                folderPath: Program.FolderPath,
                outputWriter: csvOutputWriter,
                ticketFormatter: new TicketCsvFormatter()
            ).Execute();

            Console.WriteLine($"Tickets data saved to {outputPath}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}