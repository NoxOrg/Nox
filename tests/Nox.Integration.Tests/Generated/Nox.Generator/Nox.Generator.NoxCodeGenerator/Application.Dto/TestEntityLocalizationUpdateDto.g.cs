// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;
namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationUpdateDto : IEntityDto<TestEntityLocalizationEntity>
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