﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto
{
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public MoneyDto PhysicalMoney { get; set; } = default!;
}