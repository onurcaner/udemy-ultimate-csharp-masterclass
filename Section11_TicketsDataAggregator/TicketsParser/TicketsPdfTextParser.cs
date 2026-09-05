using System.Globalization;
using Section11_TicketsDataAggregator.Tickets;

namespace Section11_TicketsDataAggregator.TicketsParser;

internal class TicketsPdfTextParser
{
    private static readonly Dictionary<string, CultureInfo> s_domainToCultureInfoMapping = new()
    {
        { "com", CultureInfo.InvariantCulture },
        { "fr", CultureInfo.GetCultureInfo("fr-FR") },
        { "jp", CultureInfo.GetCultureInfo("jp-JP") }
    };

    public static IEnumerable<ITicket> Parse(string text)
    {
        List<ILocalTicketDto> localTicketDtos = new();
        LocalTicketDtoBuilder localTicketDtoBuilder = new();
        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        // To Local DTOs
        foreach (string line in text.Split(Environment.NewLine))
        {
            (string information, InformationType informationType) = TicketsPdfTextParser.ParseLine(line);
            switch (informationType)
            {
                case InformationType.Title:
                {
                    localTicketDtoBuilder.SetTitle(information);
                    break;
                }

                case InformationType.Date:
                {
                    localTicketDtoBuilder.SetDate(information);
                    break;
                }

                case InformationType.Time:
                {
                    localTicketDtoBuilder.SetTime(information);
                    localTicketDtos.Add(
                        localTicketDtoBuilder.Build()
                    );
                    break;
                }

                case InformationType.TopLevelDomain:
                {
                    bool status = TicketsPdfTextParser.s_domainToCultureInfoMapping.TryGetValue(
                        information,
                        out CultureInfo? foundCultureInfo
                    );
                    if (!status || foundCultureInfo is null)
                    {
                        break;
                    }

                    cultureInfo = foundCultureInfo;
                    break;
                }
            }
        }

        // To Tickets
        IEnumerable<ITicket> tickets = localTicketDtos.Select(localTicketDto => new Ticket
        {
            Title = localTicketDto.Title,
            DateTime = DateTime.Parse($"{localTicketDto.Date} {localTicketDto.Time}", cultureInfo)
        });

        return tickets;
    }

    private static (string information, InformationType informationType) ParseLine(string line)
    {
        if (line.StartsWith("Title:"))
        {
            return (
                information: line.Replace("Title:", "").Trim(),
                informationType: InformationType.Title
            );
        }


        if (line.StartsWith("Date:"))
        {
            return (
                information: line.Replace("Date:", "").Trim(),
                informationType: InformationType.Date
            );
        }

        if (line.StartsWith("Time:"))
        {
            return (
                information: line.Replace("Time:", "").Trim(),
                informationType: InformationType.Time
            );
        }

        if (line.StartsWith("Visit us:"))
        {
            return (
                information: line.Replace("Visit us:", "").Replace("www.ourCinema.", "").Trim(),
                informationType: InformationType.TopLevelDomain
            );
        }

        return (
            information: "",
            informationType: InformationType.Other
        );
    }

    private enum InformationType
    {
        Title = 1,
        Date,
        Time,
        TopLevelDomain,
        Other
    }
}