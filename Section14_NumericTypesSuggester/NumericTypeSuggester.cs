namespace Section14_NumericTypesSuggester;

internal static class NumericTypeSuggester
{
    public static SuggestedType DeriveSuggestedType(FormState formState)
    {
        // Not enough data
        if (formState.MinValue == "" || formState.MaxValue == "")
        {
            return SuggestedType.NotEnoughData;
        }

        // Impossible
        if (!formState.IsMinValueParsable || !formState.IsMaxValueParsable)
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        // Min > Max
        if (!formState.IsMaxValueGteMinValue)
        {
            return SuggestedType.MinValueGtMaxValue;
        }

        // Decimal
        if (formState.IsPrecise && !formState.IsIntegral)
        {
            return NumericTypeSuggester.DeriveSuggestedPreciseType(formState);
        }

        // Floating Point
        if (!formState.IsIntegral)
        {
            return NumericTypeSuggester.DeriveSuggestedFloatingPointType(formState);
        }

        // Integral
        if (formState.IsIntegral)
        {
            return NumericTypeSuggester.DeriveSuggestedIntegralType(formState);
        }

        throw new NotImplementedException();
    }

    private static SuggestedType DeriveSuggestedPreciseType(FormState formState)
    {
        if (!decimal.TryParse(formState.MinValue, out decimal _))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        if (!decimal.TryParse(formState.MaxValue, out decimal _))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        return SuggestedType.Decimal;
    }

    private static SuggestedType DeriveSuggestedFloatingPointType(FormState formState)
    {
        if (!double.TryParse(formState.MinValue, out double minValue))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        if (!double.TryParse(formState.MaxValue, out double maxValue))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        if (minValue >= float.MinValue && maxValue <= float.MaxValue)
        {
            return SuggestedType.Float;
        }

        if (minValue >= double.MinValue && maxValue <= double.MaxValue)
        {
            return SuggestedType.Double;
        }

        return SuggestedType.ImpossibleRepresentation;
    }

    private static SuggestedType DeriveSuggestedIntegralType(FormState formState)
    {
        if (!double.TryParse(formState.MinValue, out double minValue))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        if (!double.TryParse(formState.MaxValue, out double maxValue))
        {
            return SuggestedType.ImpossibleRepresentation;
        }

        if (minValue >= sbyte.MinValue && maxValue <= sbyte.MaxValue)
        {
            return SuggestedType.SByte;
        }

        if (minValue >= byte.MinValue && maxValue <= byte.MaxValue)
        {
            return SuggestedType.Byte;
        }

        if (minValue >= short.MinValue && maxValue <= short.MaxValue)
        {
            return SuggestedType.Short;
        }

        if (minValue >= ushort.MinValue && maxValue <= ushort.MaxValue)
        {
            return SuggestedType.UShort;
        }

        if (minValue >= int.MinValue && maxValue <= int.MaxValue)
        {
            return SuggestedType.Int;
        }

        if (minValue >= uint.MinValue && maxValue <= uint.MaxValue)
        {
            return SuggestedType.UInt;
        }

        if (minValue >= long.MinValue && maxValue <= long.MaxValue)
        {
            return SuggestedType.Long;
        }

        if (minValue >= ulong.MinValue && maxValue <= ulong.MaxValue)
        {
            return SuggestedType.ULong;
        }

        return SuggestedType.BigInteger;
    }
}