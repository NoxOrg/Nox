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
public partial class SecondTestEntityExactlyOnePartialUpdateDto : SecondTestEntityExactlyOnePartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityExactlyOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityExactlyOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField2 { get; set; } = default!;
}