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
public partial class TestEntityTwoRelationshipsManyToManyUpdateDto : TestEntityTwoRelationshipsManyToManyUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsManyToManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsManyToMany>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipOneId { get; set; } = new();

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<System.String> TestRelationshipTwoId { get; set; } = new();
}