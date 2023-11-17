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
public partial class TestEntityOwnedRelationshipZeroOrOneUpdateDto : TestEntityOwnedRelationshipZeroOrOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityOwnedRelationshipZeroOrOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityOwnedRelationshipZeroOrOne>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrOne Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrOne ZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto? SecondTestEntityOwnedRelationshipZeroOrOne { get; set; } = null!;
}