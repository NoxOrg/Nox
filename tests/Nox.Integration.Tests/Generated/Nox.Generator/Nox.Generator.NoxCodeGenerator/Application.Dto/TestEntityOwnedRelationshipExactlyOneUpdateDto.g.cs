// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class TestEntityOwnedRelationshipExactlyOneUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }
    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecEntityOwnedRelExactlyOne ExactlyOne SecEntityOwnedRelExactlyOnes
    /// </summary>
    public virtual SecEntityOwnedRelExactlyOneUpsertDto SecEntityOwnedRelExactlyOne { get; set; } = null!;
}