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
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuidPartialUpdateDto : TestEntityWithNuidPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing nuid
/// </summary>
public partial class TestEntityWithNuidPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityWithNuid>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
}