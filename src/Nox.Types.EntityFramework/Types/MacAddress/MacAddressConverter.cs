using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class MacAddressConverter : ValueConverter<MacAddress, string>
{
    public MacAddressConverter() : base(macAddress => macAddress.Value, macAddressValue => MacAddress.From(macAddressValue)) { }
}