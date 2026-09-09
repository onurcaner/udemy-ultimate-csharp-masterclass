namespace Section12_TicketsDataAggregator.Tickets;

internal interface ITicket
{
    public string Title { get; }
    public DateTime DateTime { get; }
}