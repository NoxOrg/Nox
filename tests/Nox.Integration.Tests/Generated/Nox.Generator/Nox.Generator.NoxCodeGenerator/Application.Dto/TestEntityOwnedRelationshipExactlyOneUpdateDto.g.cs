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
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipExactlyOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipExactlyOneUpdateDto SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;
}