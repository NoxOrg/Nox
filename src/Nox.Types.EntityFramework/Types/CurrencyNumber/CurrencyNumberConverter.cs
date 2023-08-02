using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class CurrencyNumberConverter : ValueConverter<CurrencyNumber, short>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyNumberConverter" /> class.
    /// </summary>
    public CurrencyNumberConverter() : base(currencyNumber => currencyNumber.Value, currencyNumberValue => CurrencyNumber.FromDatabase(currencyNumberValue))
    {
    }
}