// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityForUniqueConstraintsCreateDto : TestEntityForUniqueConstraintsCreateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class TestEntityForUniqueConstraintsCreateDtoBase : IEntityDto<TestEntityForUniqueConstraintsEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueNumberField is required")]
    
    public virtual System.Int16 UniqueNumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueCountryCode is required")]
    
    public virtual System.String UniqueCountryCode { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueCurrencyCode is required")]
    
    public virtual System.String UniqueCurrencyCode { get; set; } = default!;
}