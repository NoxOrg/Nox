﻿// Generated

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
public partial class SecondTestEntityTwoRelationshipsOneToOneCreateDto : SecondTestEntityTwoRelationshipsOneToOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToOneCreateDtoBase 
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
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String? TextTestField2 { get; set; }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipOneOnOtherSideId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipOneOnOtherSide { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipTwoOnOtherSideId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipTwoOnOtherSide { get; set; } = default!;
}