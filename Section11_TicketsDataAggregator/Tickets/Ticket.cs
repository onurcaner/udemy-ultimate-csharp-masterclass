namespace Section11_TicketsDataAggregator.Tickets;

internal record Ticket : ITicket
{
    public required string Title { get; init; }
    public required DateTime DateTime { get; init; }

    public override string ToString()
    {
        return $"{this.Title} {this.DateTime:O}";
    }
}