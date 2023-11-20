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
/// Entity created for testing constraints.
/// </summary>
public partial class TestEntityForUniqueConstraintsCreateDto : TestEntityForUniqueConstraintsCreateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class TestEntityForUniqueConstraintsCreateDtoBase : IEntityDto<DomainNamespace.TestEntityForUniqueConstraints>
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
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "UniqueNumberField is required")]
    
    public virtual System.Int16 UniqueNumberField { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "UniqueCountryCode is required")]
    
    public virtual System.String UniqueCountryCode { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "UniqueCurrencyCode is required")]
    
    public virtual System.String UniqueCurrencyCode { get; set; } = default!;
}