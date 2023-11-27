﻿// Generated

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
public partial class TestEntityLocalizationUpdateDto : TestEntityLocalizationUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityLocalization: Entity created for testing localization.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityLocalizationPatchDto: { { className} }
{

}

/// <summary>
/// Entity created for testing localization
/// </summary>
public partial class TestEntityLocalizationUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityLocalization>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public virtual System.String TextFieldToLocalize { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
}