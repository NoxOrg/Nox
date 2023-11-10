// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization Localized Create DTO.
/// </summary>
public partial class TestEntityLocalizationLocalizedCreateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    internal System.String Id { get; set; } = default!;
    
    internal System.String CultureCode { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String TextFieldToLocalize { get; set; } = default!;
}