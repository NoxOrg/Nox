// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// The list of currencies.
/// </summary>
public partial class CurrencyCreateDto
{
    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public String Name { get; set; } = default!;
}