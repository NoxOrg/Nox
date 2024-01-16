// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationUpdateDto : TestEntityLocalizationUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing localization
/// </summary>
public partial class TestEntityLocalizationUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public virtual System.String? TextFieldToLocalize { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16? NumberField { get; set; }
}