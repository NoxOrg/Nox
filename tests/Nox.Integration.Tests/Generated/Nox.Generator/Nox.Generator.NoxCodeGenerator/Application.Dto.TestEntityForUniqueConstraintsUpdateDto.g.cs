// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public partial class TestEntityForUniqueConstraintsUpdateDto : IEntityDto<TestEntityForUniqueConstraints>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public System.String TextField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public System.Int16 NumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueNumberField is required")]
    
    public System.Int16 UniqueNumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueCountryCode is required")]
    
    public System.String UniqueCountryCode { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "UniqueCurrencyCode is required")]
    
    public System.String UniqueCurrencyCode { get; set; } = default!;
}