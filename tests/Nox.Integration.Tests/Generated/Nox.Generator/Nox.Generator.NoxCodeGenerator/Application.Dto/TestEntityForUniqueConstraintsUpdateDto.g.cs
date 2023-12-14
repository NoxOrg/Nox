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
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String? TextField { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16? NumberField { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "UniqueNumberField is required")]
    
    public virtual System.Int16? UniqueNumberField { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "UniqueCountryCode is required")]
    
    public virtual System.String? UniqueCountryCode { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "UniqueCurrencyCode is required")]
    
    public virtual System.String? UniqueCurrencyCode { get; set; }
}