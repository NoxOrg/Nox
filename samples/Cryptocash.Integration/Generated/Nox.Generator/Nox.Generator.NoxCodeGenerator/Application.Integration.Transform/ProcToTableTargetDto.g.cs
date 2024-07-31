// Generated
#nullable enable

using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public sealed class ProcToTableTargetDto: NoxEntityTargetDto
{
    public System.Int32 CountryId { get; set; }
    public System.String Name { get; set; } = string.Empty;
    public System.Int32 Population { get; set; }
}