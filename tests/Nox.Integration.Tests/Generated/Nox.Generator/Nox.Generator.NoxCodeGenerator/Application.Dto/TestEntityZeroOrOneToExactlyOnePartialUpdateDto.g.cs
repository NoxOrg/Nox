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
public partial class TestEntityZeroOrOneToExactlyOnePartialUpdateDto : TestEntityZeroOrOneToExactlyOnePartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityZeroOrOneToExactlyOnePartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrOneToExactlyOne>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}