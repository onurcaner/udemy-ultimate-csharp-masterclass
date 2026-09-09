using System.Numerics;

namespace Section14_NumericTypesSuggester;

internal class StringNumber
{
    public StringNumber(string initialValue = "")
    {
        this.Value = initialValue;
    }

    public string Value { get; set; }

    public bool IsParsable =>
        decimal.TryParse(this.Value, out decimal _)
        || this.TryParseBigIntegerScientific(out BigInteger _)
        || double.TryParse(this.Value, out double _);

    public static int Compare(StringNumber left, StringNumber right)
    {
        if (decimal.TryParse(left.Value, out decimal leftDecimal)
            && decimal.TryParse(right.Value, out decimal rightDecimal))
        {
            decimal difference = leftDecimal - rightDecimal;
            return difference == 0 ? 0 : difference > 0 ? 1 : -1;
        }

        if (double.TryParse(left.Value, out double leftDouble)
            && double.TryParse(right.Value, out double rightDouble)
            && leftDouble is not double.NegativeInfinity
            && leftDouble is not double.PositiveInfinity
            && rightDouble is not double.NegativeInfinity
            && rightDouble is not double.PositiveInfinity)
        {
            double difference = leftDouble - rightDouble;
            return difference == 0 ? 0 : difference > 0 ? 1 : -1;
        }

        if (left.TryParseBigIntegerScientific(out BigInteger leftBigInteger)
            && right.TryParseBigIntegerScientific(out BigInteger rightBigInteger))
        {
            BigInteger difference = leftBigInteger - rightBigInteger;
            return difference == 0 ? 0 : difference > 0 ? 1 : -1;
        }

        if (left.Value.Contains('e'))
        {
        }


        throw new Exception();
    }

    public bool TryParseBigIntegerScientific(out BigInteger result)
    {
        if (BigInteger.TryParse(this.Value, out BigInteger bigInteger))
        {
            result = bigInteger;
            return true;
        }

        string[] parts = this.Value.Split('e');
        if (parts.Length != 2)
        {
            result = BigInteger.Zero;
            return false;
        }

        if (BigInteger.TryParse(parts[0], out BigInteger mantissa) && int.TryParse(parts[1], out int exponent))
        {
            result = mantissa * BigInteger.Pow(10, exponent);
            return true;
        }

        result = BigInteger.Zero;
        return false;
    }
}