// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationCreateDto : TestEntityLocalizationCreateDtoBase
{

}

/// <summary>
/// Entity created for testing localization.
/// </summary>
public abstract class TestEntityLocalizationCreateDtoBase 
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public virtual System.String? TextFieldToLocalize { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16? NumberField { get; set; }
}