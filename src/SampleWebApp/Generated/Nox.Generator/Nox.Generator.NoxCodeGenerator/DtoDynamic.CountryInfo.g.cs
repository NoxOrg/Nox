﻿// Generated

#nullable enable

// Generated by DtoDynamicGenerator::GenerateDto

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.DataTransferObjects;

public partial class CountryInfo : IDynamicDto
{
    
    /// <summary>
    /// The country's Id.
    /// </summary>
    public CountryCode2? CountryId { get; set; } = null!;
    
    
    /// <summary>
    /// The country name.
    /// </summary>
    public Text? CountryName { get; set; } = null!;
}
