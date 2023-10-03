// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class SecondTestEntityTwoRelationshipsOneToManyCreateDto : SecondTestEntityTwoRelationshipsOneToManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToManyCreateDtoBase : IEntityDto<SecondTestEntityTwoRelationshipsOneToMany>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public System.String? TestRelationshipOneOnOtherSideId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TestEntityTwoRelationshipsOneToManyCreateDto? TestRelationshipOneOnOtherSide { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public System.String? TestRelationshipTwoOnOtherSideId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TestEntityTwoRelationshipsOneToManyCreateDto? TestRelationshipTwoOnOtherSide { get; set; } = default!;
}