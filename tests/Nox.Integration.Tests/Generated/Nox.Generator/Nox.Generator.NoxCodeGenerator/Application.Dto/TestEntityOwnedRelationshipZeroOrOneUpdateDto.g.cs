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
/// Patch entity TestEntityOwnedRelationshipZeroOrOne: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityOwnedRelationshipZeroOrOnePatchDto: { { className} }
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
    public virtual SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto? SecondTestEntityOwnedRelationshipZeroOrOne { get; set; } = null!;
}