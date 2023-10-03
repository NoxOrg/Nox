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

public partial class SecondTestEntityTwoRelationshipsOneToOneCreateDto : SecondTestEntityTwoRelationshipsOneToOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToOneCreateDtoBase : IEntityDto<SecondTestEntityTwoRelationshipsOneToOne>
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
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipOneOnOtherSideId { get; set; } = default!;
    public virtual TestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipOneOnOtherSide { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public System.String? TestRelationshipTwoOnOtherSideId { get; set; } = default!;
    public virtual TestEntityTwoRelationshipsOneToOneCreateDto? TestRelationshipTwoOnOtherSide { get; set; } = default!;
}