using Section11_TicketsDataAggregator.Tickets;

namespace Section11_TicketsDataAggregator.TicketFormatter;

internal class TicketTextualFormatter : ITicketFormatter
{
    public string CreateHeader()
    {
        int isoDateLength = DateTime.Now.ToUniversalTime().ToString("O").Length;
        string date = "DateTime:".PadRight(isoDateLength, ' ');
        string title = "Title:";
        return $"{date}\t{title}";
    }

    public string FormatTicket(ITicket ticket)
    {
        return $"{ticket.DateTime.ToUniversalTime():O}\t{ticket.Title}";
    }

    public IEnumerable<string> FormatTickets(IEnumerable<ITicket> tickets)
    {
        return tickets.Select(this.FormatTicket);
    }
}