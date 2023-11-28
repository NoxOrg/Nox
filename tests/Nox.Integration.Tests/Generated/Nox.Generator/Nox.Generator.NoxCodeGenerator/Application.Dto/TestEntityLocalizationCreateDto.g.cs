// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

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
public abstract class TestEntityLocalizationCreateDtoBase : IEntityDto<DomainNamespace.TestEntityLocalization>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public virtual System.String TextFieldToLocalize { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
}