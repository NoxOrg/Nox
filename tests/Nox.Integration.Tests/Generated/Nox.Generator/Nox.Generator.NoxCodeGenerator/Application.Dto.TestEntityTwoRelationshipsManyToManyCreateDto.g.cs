// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityTwoRelationshipsManyToManyCreateDto : TestEntityTwoRelationshipsManyToManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsManyToManyCreateDtoBase : IEntityDto<TestEntityTwoRelationshipsManyToManyEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<SecondTestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipOne { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<SecondTestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipTwo { get; set; } = new();
}