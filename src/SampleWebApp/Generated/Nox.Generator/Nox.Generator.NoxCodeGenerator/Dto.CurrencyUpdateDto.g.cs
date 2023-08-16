// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// The list of currencies.
/// </summary>
public partial class CurrencyUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
}