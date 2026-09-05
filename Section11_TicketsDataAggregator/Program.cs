using Section11_TicketsDataAggregator.OutputWriter;
using Section11_TicketsDataAggregator.PdfReader;
using Section11_TicketsDataAggregator.TicketFormatter;

namespace Section11_TicketsDataAggregator;

// https://docs.google.com/document/d/1nIq2gD-1uwCnQz5OrDpouEW1j3GKSRGwBN_07moVFd8/
internal class Program
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