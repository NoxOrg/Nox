// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class TestEntityOwnedRelationshipExactlyOneCreateDto : TestEntityOwnedRelationshipExactlyOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipExactlyOneCreateDtoBase 
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }

    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecEntityOwnedRelExactlyOne ExactlyOne SecEntityOwnedRelExactlyOnes
    /// </summary>
    public virtual SecEntityOwnedRelExactlyOneUpsertDto SecEntityOwnedRelExactlyOne { get; set; } = null!;
}