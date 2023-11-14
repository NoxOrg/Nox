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
/// Entity created for testing constraints.
/// </summary>
public partial class TestEntityForUniqueConstraintsUpdateDto : TestEntityForUniqueConstraintsUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints
/// </summary>
public partial class TestEntityForUniqueConstraintsUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityForUniqueConstraints>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "UniqueNumberField is required")]
    
    public virtual System.Int16 UniqueNumberField { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "UniqueCountryCode is required")]
    
    public virtual System.String UniqueCountryCode { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "UniqueCurrencyCode is required")]
    
    public virtual System.String UniqueCurrencyCode { get; set; } = default!;
}