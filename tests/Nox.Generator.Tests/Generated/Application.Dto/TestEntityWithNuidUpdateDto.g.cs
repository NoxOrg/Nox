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
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuidUpdateDto : TestEntityWithNuidUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityWithNuid: Entity created for testing nuid.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityWithNuidPatchDto: TestEntityWithNuidUpdateDto
{
    
}

/// <summary>
/// Entity created for testing nuid
/// </summary>
public partial class TestEntityWithNuidUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityWithNuid>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
}