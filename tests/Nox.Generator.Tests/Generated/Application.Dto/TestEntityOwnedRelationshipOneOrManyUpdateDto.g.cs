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
public partial class TestEntityOwnedRelationshipOneOrManyUpdateDto : TestEntityOwnedRelationshipOneOrManyUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityOwnedRelationshipOneOrMany: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityOwnedRelationshipOneOrManyPatchDto: TestEntityOwnedRelationshipOneOrManyUpdateDto
{
    
}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipOneOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipOneOrMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecondTestEntityOwnedRelationshipOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> SecondTestEntityOwnedRelationshipOneOrManies { get; set; } = new();
}