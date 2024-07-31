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
public partial class TestEntityTwoRelationshipsManyToManyCreateDto : TestEntityTwoRelationshipsManyToManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsManyToManyCreateDtoBase 
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
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipOneId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<SecondTestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipOne { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipTwoId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<SecondTestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipTwo { get; set; } = new();
}