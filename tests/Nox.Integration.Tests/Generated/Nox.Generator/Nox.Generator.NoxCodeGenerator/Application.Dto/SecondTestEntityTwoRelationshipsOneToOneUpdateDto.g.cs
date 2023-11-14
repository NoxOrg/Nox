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
public partial class SecondTestEntityTwoRelationshipsOneToOneUpdateDto : SecondTestEntityTwoRelationshipsOneToOneUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityTwoRelationshipsOneToOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityTwoRelationshipsOneToOne>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    
    public virtual System.String? TestRelationshipOneOnOtherSideId { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    
    public virtual System.String? TestRelationshipTwoOnOtherSideId { get; set; } = default!;
}