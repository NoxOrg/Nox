// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNames:IOwnedEntity
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;
}