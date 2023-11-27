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
/// Patch entity TestEntityTwoRelationshipsManyToMany: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityTwoRelationshipsManyToManyPatchDto: { { className} }
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsManyToManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsManyToMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}