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
public partial class TestEntityExactlyOneToZeroOrManyPartialUpdateDto : TestEntityExactlyOneToZeroOrManyPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityExactlyOneToZeroOrManyPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityExactlyOneToZeroOrMany>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}