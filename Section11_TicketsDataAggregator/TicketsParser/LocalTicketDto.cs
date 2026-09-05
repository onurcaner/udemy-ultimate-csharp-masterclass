namespace Section11_TicketsDataAggregator.TicketsParser;

internal record LocalTicketDto : ILocalTicketDto
{
    public required string Title { get; init; }
    public required string Date { get; init; }
    public required string Time { get; init; }
}