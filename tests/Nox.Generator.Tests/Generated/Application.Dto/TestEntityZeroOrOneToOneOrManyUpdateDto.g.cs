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
public partial class TestEntityZeroOrOneToOneOrManyUpdateDto : TestEntityZeroOrOneToOneOrManyUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityZeroOrOneToOneOrMany: Entity created for testing database.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityZeroOrOneToOneOrManyPatchDto: TestEntityZeroOrOneToOneOrManyUpdateDto
{
    
}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityZeroOrOneToOneOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityZeroOrOneToOneOrMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}