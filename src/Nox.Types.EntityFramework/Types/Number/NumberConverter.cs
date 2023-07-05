using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace Nox.Types.EntityFramework.Types;

public class NumberToDecimalConverter : ValueConverter<Number, decimal>
{
    public NumberToDecimalConverter() : base(number => number.Value, numberValue => Number.From(numberValue)) { }
}

public class NumberToByteConverter : ValueConverter<Number, byte>
{
    public NumberToByteConverter() : base(number => (byte)number.Value, numberValue => Number.From(numberValue)) { }
}

public class NumberToShortConverter : ValueConverter<Number, short>
{
    public NumberToShortConverter() : base(number => (short)number.Value, numberValue => Number.From(numberValue)) { }
}

public class NumberToInt32Converter : ValueConverter<Number, int>
{
    public NumberToInt32Converter() : base(number => (int)number.Value, numberValue => Number.From(numberValue)) { }
}

public class NumberToInt64Converter : ValueConverter<Number, long>
{
    public NumberToInt64Converter() : base(number => (long)number.Value, numberValue => Number.From(numberValue)) { }
}

public class NumberToDoubleConverter : ValueConverter<Number, double>
{
    public NumberToDoubleConverter() : base(number => (double)number.Value, numberValue => Number.From(numberValue)) { }
}