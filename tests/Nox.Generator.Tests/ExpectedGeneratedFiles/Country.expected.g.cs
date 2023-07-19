// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
public partial class Country : AuditableEntityBase
{
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Nuid Id  => Nuid.From(string.Join(".", Name.Value.ToString(), FormalName.Value.ToString()));
    
    /// <summary>
    /// The country's common name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
    
    /// <summary>
    /// The country's official name (required).
    /// </summary>
    public Text FormalName { get; set; } = null!;
}
