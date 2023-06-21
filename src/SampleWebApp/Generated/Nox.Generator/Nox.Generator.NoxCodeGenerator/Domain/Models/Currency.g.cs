// generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;

namespace SampleService.Domain;

/// <summary>
/// The list of currencies.
/// </summary>
public partial class Currency : AuditableEntityBase
{
    
    /// <summary>
    /// Currency is legal tender for ZeroOrMany Countries
    /// </summary>
    public List<Country> Countries { get; set; } = null!;
}
