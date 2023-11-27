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
public partial class TestEntityOwnedRelationshipZeroOrManyUpdateDto : TestEntityOwnedRelationshipZeroOrManyUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityOwnedRelationshipZeroOrMany: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityOwnedRelationshipZeroOrManyPatchDto: TestEntityOwnedRelationshipZeroOrManyUpdateDto
{
    
}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipZeroOrMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrMany Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrMany ZeroOrMany SecondTestEntityOwnedRelationshipZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> SecondTestEntityOwnedRelationshipZeroOrManies { get; set; } = new();
}