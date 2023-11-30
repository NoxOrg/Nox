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
/// Entity created for testing localization.
/// </summary>
public partial class TestEntityLocalizationPartialUpdateDto : TestEntityLocalizationPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing localization
/// </summary>
public partial class TestEntityLocalizationPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityLocalization>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextFieldToLocalize { get; set; } = default!;
    /// <summary>
    /// 
    /// </summary>
    public virtual System.Int16 NumberField { get; set; } = default!;
}