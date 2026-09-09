using Section12_TicketsDataAggregator.Tickets;

namespace Section12_TicketsDataAggregator.TicketFormatter;

internal class TicketCsvFormatter : ITicketFormatter
{
    public string CreateHeader()
    {
        return "Title,DateTime";
    }

    public string FormatTicket(ITicket ticket)
    {
        string escapedTitle = TicketCsvFormatter.Escape(ticket.Title);
        return $"{escapedTitle},{ticket.DateTime.ToUniversalTime():O}";
    }

    public IEnumerable<string> FormatTickets(IEnumerable<ITicket> tickets)
    {
        return tickets.Select(this.FormatTicket);
    }

    private static string Escape(string field)
    {
        if (field.Contains(',') || field.Contains('"') || field.Contains('\n'))
        {
            return '"' + field.Replace("\"", "\"\"") + '"';
        }

        return field;
    }
}