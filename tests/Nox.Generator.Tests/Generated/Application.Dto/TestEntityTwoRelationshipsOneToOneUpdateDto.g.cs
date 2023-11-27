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
public partial class TestEntityTwoRelationshipsOneToOneUpdateDto : TestEntityTwoRelationshipsOneToOneUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityTwoRelationshipsOneToOne: .
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityTwoRelationshipsOneToOnePatchDto: TestEntityTwoRelationshipsOneToOneUpdateDto
{
    
}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsOneToOneUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToOne>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}