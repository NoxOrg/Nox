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
/// Entity created for testing database.
/// </summary>
public partial class ThirdTestEntityExactlyOnePartialUpdateDto : ThirdTestEntityExactlyOnePartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class ThirdTestEntityExactlyOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.ThirdTestEntityExactlyOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}