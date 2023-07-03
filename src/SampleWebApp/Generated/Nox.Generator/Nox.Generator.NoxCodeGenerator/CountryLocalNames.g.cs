// Generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The identifier (primary key) for a CountryLocalNames.
/// </summary>
public class CountryLocalNamesId : ValueObject<Text,CountryLocalNamesId> {}

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNames : AuditableEntityBase
{
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public CountryLocalNamesId Id { get; set; } = null!;
}
