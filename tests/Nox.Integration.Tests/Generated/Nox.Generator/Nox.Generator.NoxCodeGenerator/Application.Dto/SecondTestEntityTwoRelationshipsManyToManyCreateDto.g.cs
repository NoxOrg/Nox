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

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityTwoRelationshipsManyToManyCreateDto : SecondTestEntityTwoRelationshipsManyToManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsManyToManyCreateDtoBase : IEntityDto<DomainNamespace.SecondTestEntityTwoRelationshipsManyToMany>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String? TextTestField2 { get; set; }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany First relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipOneOnOtherSideId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipOneOnOtherSide { get; set; } = new();

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany Second relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipTwoOnOtherSideId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityTwoRelationshipsManyToManyCreateDto> TestRelationshipTwoOnOtherSide { get; set; } = new();
}