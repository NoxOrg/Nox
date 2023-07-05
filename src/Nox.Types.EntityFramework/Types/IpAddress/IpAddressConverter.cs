using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class IpAddressConverter : ValueConverter<IpAddress, string>
{
    public IpAddressConverter() : base(ipAddress => ipAddress.Value, ipAddressValue => IpAddress.From(ipAddressValue)) { }
}
