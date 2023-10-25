// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationUpdateDto : IEntityDto<DomainNamespace.TestEntityLocalization>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public System.String TextFieldToLocalize { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public System.Int16 NumberField { get; set; } = default!;
}