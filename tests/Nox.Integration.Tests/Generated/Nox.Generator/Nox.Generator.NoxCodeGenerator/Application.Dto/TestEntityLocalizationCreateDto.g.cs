// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityLocalizationCreateDto : TestEntityLocalizationCreateDtoBase
{

}

/// <summary>
/// Entity created for testing localization.
/// </summary>
public abstract class TestEntityLocalizationCreateDtoBase : IEntityDto<TestEntityLocalizationEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextFieldToLocalize is required")]
    
    public virtual System.String TextFieldToLocalize { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public virtual System.Int16 NumberField { get; set; } = default!;
}