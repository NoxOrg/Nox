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
/// Entity created for testing auto number usages.
/// </summary>
public partial class TestEntityForAutoNumberUsagesPartialUpdateDto : TestEntityForAutoNumberUsagesPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages
/// </summary>
public partial class TestEntityForAutoNumberUsagesPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityForAutoNumberUsages>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextField { get; set; } = default!;
}