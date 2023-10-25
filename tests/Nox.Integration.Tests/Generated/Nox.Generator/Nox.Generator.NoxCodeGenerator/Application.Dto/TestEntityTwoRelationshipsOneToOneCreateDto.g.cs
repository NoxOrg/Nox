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

public partial class TestEntityTwoRelationshipsOneToOneCreateDto : TestEntityTwoRelationshipsOneToOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToOne>
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
    /// TestEntityTwoRelationshipsOneToOne First relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual SecondTestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipOne { get; set; } = default!;

    /// <summary>
    /// TestEntityTwoRelationshipsOneToOne Second relationship to the same entity ExactlyOne SecondTestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipTwoId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual SecondTestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipTwo { get; set; } = default!;
}