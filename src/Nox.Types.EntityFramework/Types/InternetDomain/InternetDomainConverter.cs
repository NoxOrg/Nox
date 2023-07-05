using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class InternetDomainConverter : ValueConverter<InternetDomain, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternetDomainConverter" /> class.
    /// </summary>
    public InternetDomainConverter() : base(internetDomain => internetDomain.Value, internetDomainValue => InternetDomain.From(internetDomainValue))
    {
    }
}