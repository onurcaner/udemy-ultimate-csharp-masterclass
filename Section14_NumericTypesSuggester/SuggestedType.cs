namespace Section14_NumericTypesSuggester;

internal enum SuggestedType
{
    NotEnoughData = 1,
    MinValueGtMaxValue,
    ImpossibleRepresentation,

    Decimal,
    Double,
    Float,

    BigInteger,
    ULong,
    Long,
    UInt,
    Int,
    UShort,
    Short,
    Byte,
    SByte
}