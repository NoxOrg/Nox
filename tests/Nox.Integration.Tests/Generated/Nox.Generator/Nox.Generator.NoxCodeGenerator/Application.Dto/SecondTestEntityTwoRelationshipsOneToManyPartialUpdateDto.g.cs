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
public partial class SecondTestEntityTwoRelationshipsOneToManyPartialUpdateDto : SecondTestEntityTwoRelationshipsOneToManyPartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityTwoRelationshipsOneToManyPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField2 { get; set; } = default!;
}