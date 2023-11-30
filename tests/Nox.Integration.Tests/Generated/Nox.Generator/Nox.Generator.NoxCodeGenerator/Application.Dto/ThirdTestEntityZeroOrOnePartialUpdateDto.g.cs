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
public partial class ThirdTestEntityZeroOrOnePartialUpdateDto : ThirdTestEntityZeroOrOnePartialUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class ThirdTestEntityZeroOrOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.ThirdTestEntityZeroOrOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField2 { get; set; } = default!;
}