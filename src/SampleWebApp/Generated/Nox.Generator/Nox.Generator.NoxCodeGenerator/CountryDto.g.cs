﻿// Generated

#nullable enable

// Generated by DtoGenerator::GenerateDto

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.DataTransferObjects;

/// <summary>
/// Dto for country information.
/// </summary>
public partial class CountryDto : IDynamicDto
{
    /// <summary>
    /// The identity of the country, the Iso Alpha 2 code.
    /// </summary>
    public Text? Id { get; set; } = null!;
}
