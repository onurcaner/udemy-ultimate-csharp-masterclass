using Section12_TicketsDataAggregator.Tickets;

namespace Section12_TicketsDataAggregator.TicketFormatter;

internal interface ITicketFormatter
{
    public string CreateHeader();
    public string FormatTicket(ITicket ticket);
    public IEnumerable<string> FormatTickets(IEnumerable<ITicket> tickets);
}