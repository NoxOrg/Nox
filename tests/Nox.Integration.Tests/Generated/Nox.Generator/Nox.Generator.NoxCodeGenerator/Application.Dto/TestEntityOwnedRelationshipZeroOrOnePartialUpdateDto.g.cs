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
public partial class TestEntityOwnedRelationshipZeroOrOnePartialUpdateDto : TestEntityOwnedRelationshipZeroOrOnePartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipZeroOrOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}