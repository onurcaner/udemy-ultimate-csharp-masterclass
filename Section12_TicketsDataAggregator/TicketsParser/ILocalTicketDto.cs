namespace Section12_TicketsDataAggregator.TicketsParser;

internal interface ILocalTicketDto
{
    public string Title { get; }
    public string Date { get; }
    public string Time { get; }
}