namespace Section09_StarWarsPlanetStats.TablePrinter;

public class UniversalTablePrinter
{
    private const char ColumnSeparator = '|';
    private const char RowSeparator = '-';

    private readonly int _columnCount;
    private readonly int _columnSize;


    public UniversalTablePrinter(int columnCount, int columnSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(columnCount);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(columnSize);

        this._columnCount = columnCount;
        this._columnSize = columnSize;
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
        Console.WriteLine(this.FormatRow(columns));
    }

    public void PrintRowSeparator()
    {
        Console.WriteLine(this.CreateRowSeparator());
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
            string.Join(UniversalTablePrinter.ColumnSeparator, paddedColumns),
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