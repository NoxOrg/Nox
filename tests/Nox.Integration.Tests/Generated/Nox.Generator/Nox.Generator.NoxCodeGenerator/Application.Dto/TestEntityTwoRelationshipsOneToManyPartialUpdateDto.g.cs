// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;



/// <summary>
/// .
/// </summary>
public partial class TestEntityTwoRelationshipsOneToManyPartialUpdateDto : TestEntityTwoRelationshipsOneToManyPartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsOneToManyPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}