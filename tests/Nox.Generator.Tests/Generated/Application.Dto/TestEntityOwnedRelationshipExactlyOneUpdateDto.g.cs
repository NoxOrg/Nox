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
public partial class TestEntityOwnedRelationshipExactlyOneUpdateDto : TestEntityOwnedRelationshipExactlyOneUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityOwnedRelationshipExactlyOne: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityOwnedRelationshipExactlyOnePatchDto: TestEntityOwnedRelationshipExactlyOneUpdateDto
{
    
}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipExactlyOne>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipExactlyOneUpsertDto SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;
}