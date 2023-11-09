// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityTwoRelationshipsOneToManyCreateDto : TestEntityTwoRelationshipsOneToManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToMany>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany First relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipOneId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<SecondTestEntityTwoRelationshipsOneToManyCreateDto> TestRelationshipOne { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany Second relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipTwoId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<SecondTestEntityTwoRelationshipsOneToManyCreateDto> TestRelationshipTwo { get; set; } = new();
}