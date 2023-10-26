// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;
namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public partial class TestEntityForAutoNumberUsagesUpdateDto : IEntityDto<TestEntityForAutoNumberUsagesEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "AutoNumberField is required")]
    
    public System.Int64 AutoNumberField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public System.String TextField { get; set; } = default!;
}