namespace Section11_TicketsDataAggregator;

internal class Program
{
    private static void Main()
    {
        string filePath = Path.Combine("ticket_pdfs", "Tickets1.pdf");
        Console.WriteLine(filePath);

        string text = new PdfFileReader().Read(filePath);
        Console.WriteLine(text);

        Console.ReadKey();
    }
}