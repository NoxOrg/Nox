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
public partial class SecondTestEntityTwoRelationshipsManyToManyUpdateDto : SecondTestEntityTwoRelationshipsManyToManyUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class SecondTestEntityTwoRelationshipsManyToManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityTwoRelationshipsManyToMany>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany First relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipOneOnOtherSideId { get; set; } = new();

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany Second relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipTwoOnOtherSideId { get; set; } = new();
}