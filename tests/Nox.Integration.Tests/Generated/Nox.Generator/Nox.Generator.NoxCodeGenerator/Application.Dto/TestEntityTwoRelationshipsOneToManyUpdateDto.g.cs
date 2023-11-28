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
public partial class TestEntityTwoRelationshipsOneToManyUpdateDto : TestEntityTwoRelationshipsOneToManyUpdateDtoBase
{

}

/// <summary>
/// 
/// </summary>
public partial class TestEntityTwoRelationshipsOneToManyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityTwoRelationshipsOneToMany>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
}