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
/// .
/// </summary>
public partial class TestEntityTwoRelationshipsOneToOnePartialUpdateDto : TestEntityTwoRelationshipsOneToOnePartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsOneToOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}