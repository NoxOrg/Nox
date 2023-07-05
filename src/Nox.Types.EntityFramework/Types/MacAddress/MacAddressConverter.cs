using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Types.EntityFramework.Types;

public class MacAddressConverter : ValueConverter<MacAddress, string>
{
    public MacAddressConverter() : base(macAddress => macAddress.Value, macAddressValue => MacAddress.From(macAddressValue)) { }
}

public class IpAddressConverter : ValueConverter<IpAddress, string>
{
    public IpAddressConverter() : base(ipAddress => ipAddress.Value, ipAddressValue => IpAddress.From(ipAddressValue)) { }
}
