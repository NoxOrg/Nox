using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class CountryNumberConverter : ValueConverter<CountryNumber, ushort>
{
    public CountryNumberConverter() : base(countryNumber => countryNumber.Value, countryNumberValue => CountryNumber.FromDatabase(countryNumberValue)) { }
}