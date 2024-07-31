// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;



/// <summary>
/// Entity created for testing constraints.
/// </summary>
public partial class TestEntityForUniqueConstraintsPartialUpdateDto : TestEntityForUniqueConstraintsPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints
/// </summary>
public partial class TestEntityForUniqueConstraintsPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextField { get; set; } = default!;
    /// <summary>
    /// 
    /// </summary>
    public virtual System.Int16 NumberField { get; set; } = default!;
    /// <summary>
    /// 
    /// </summary>
    public virtual System.Int16 UniqueNumberField { get; set; } = default!;
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String UniqueCountryCode { get; set; } = default!;
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String UniqueCurrencyCode { get; set; } = default!;
}