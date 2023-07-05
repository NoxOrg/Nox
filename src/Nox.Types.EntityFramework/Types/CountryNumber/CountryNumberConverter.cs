using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class CountryNumberConverter : ValueConverter<CountryNumber, short>
{
    public CountryNumberConverter() : base(countryNumber => countryNumber.Value, countryNumberValue => CountryNumber.From(countryNumberValue)) { }
}