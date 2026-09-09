namespace Section12_TicketsDataAggregator.TicketsParser;

internal class LocalTicketDtoBuilder
{
    private string? _date;
    private string? _time;
    private string? _title;

    public LocalTicketDtoBuilder SetTitle(string title)
    {
        this._title = title;
        return this;
    }

    public LocalTicketDtoBuilder SetDate(string date)
    {
        this._date = date;
        return this;
    }

    public LocalTicketDtoBuilder SetTime(string time)
    {
        this._time = time;
        return this;
    }

    public ILocalTicketDto Build()
    {
        if (this._title is null || this._date is null || this._time is null)
        {
            throw new ArgumentNullException(
                $"title, date, time is not set properly in {nameof(LocalTicketDtoBuilder)}");
        }

        ILocalTicketDto localTicketDto = new LocalTicketDto
        {
            Title = this._title,
            Date = this._date,
            Time = this._time
        };

        this._title = null;
        this._date = null;
        this._time = null;

        return localTicketDto;
    }
}