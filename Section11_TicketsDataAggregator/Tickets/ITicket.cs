namespace Section11_TicketsDataAggregator.Tickets;

internal interface ITicket
{
    public string Title { get; }
    public DateTime DateTime { get; }
}