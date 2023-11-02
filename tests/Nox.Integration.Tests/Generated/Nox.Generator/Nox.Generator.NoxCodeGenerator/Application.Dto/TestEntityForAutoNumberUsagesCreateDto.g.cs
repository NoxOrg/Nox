// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityForAutoNumberUsagesCreateDto : TestEntityForAutoNumberUsagesCreateDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract class TestEntityForAutoNumberUsagesCreateDtoBase : IEntityDto<TestEntityForAutoNumberUsagesEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "AutoNumberField is required")]
    
    public virtual System.Int64 AutoNumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
}