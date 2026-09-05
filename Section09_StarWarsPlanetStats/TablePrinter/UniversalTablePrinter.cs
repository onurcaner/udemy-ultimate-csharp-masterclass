namespace Section09_StarWarsPlanetStats.TablePrinter;

public class UniversalTablePrinter
{
    private const char ColumnSeparator = '|';
    private const char RowSeparator = '-';

    private readonly int _columnCount;
    private readonly int _columnSize;
    private readonly int _inlinePadding;
    private readonly ILinePrinter _linePrinter;


    public UniversalTablePrinter(
        ILinePrinter linePrinter,
        int columnCount,
        int columnSize,
        int inlinePadding
    )
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(columnCount);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(columnSize);
        ArgumentOutOfRangeException.ThrowIfNegative(inlinePadding);

        this._linePrinter = linePrinter;
        this._columnCount = columnCount;
        this._columnSize = columnSize;
        this._inlinePadding = inlinePadding;
    }

    public void PrintTable(IEnumerable<object> headerColumns, IEnumerable<IEnumerable<object>> dataMatrix)
    {
        this.PrintRowSeparator();
        this.PrintRow(headerColumns);
        this.PrintRowSeparator();
        foreach (IEnumerable<object> dataColumns in dataMatrix)
        {
            this.PrintRow(dataColumns);
        }

        this.PrintRowSeparator();
    }

    public void PrintRow(IEnumerable<object> columns)
    {
        IEnumerable<string> stringColumns = columns
            .Select(column => column.ToString())
            .Select(column => string.IsNullOrWhiteSpace(column) ? "" : column);
        this.PrintRow(stringColumns);
    }

    public void PrintRow(IEnumerable<string> columns)
    {
        this._linePrinter.PrintLine(
            this.FormatRow(columns)
        );
    }

    public void PrintRowSeparator()
    {
        this._linePrinter.PrintLine(
            this.CreateRowSeparator()
        );
    }

    private string FormatRow(IEnumerable<string> columns)
    {
        IEnumerable<string> paddedColumns = columns
            .Take(this._columnCount)
            .Select<string, string>(column =>
                column.Length > this._columnSize ? column.Substring(0, this._columnSize) : column)
            .Select<string, string>(column => column.PadRight(this._columnSize, ' '));

        string row = string.Concat(
            UniversalTablePrinter.ColumnSeparator,
            new string(' ', this._inlinePadding),
            string.Join(UniversalTablePrinter.ColumnSeparator, paddedColumns),
            new string(' ', this._inlinePadding),
            UniversalTablePrinter.ColumnSeparator
        );

        return row;
    }

    private string CreateRowSeparator()
    {
        int length = this._columnCount * this._columnSize + (this._columnCount - 1) + 2;
        string row = new(UniversalTablePrinter.RowSeparator, length);
        return row;
    }
}