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
public partial class TestEntityZeroOrOnePartialUpdateDto : TestEntityZeroOrOnePartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityZeroOrOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}