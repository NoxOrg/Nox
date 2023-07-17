// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp.Domain;

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNames : AuditableEntityBase
{
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Text Id { get; set; } = null!;
}
