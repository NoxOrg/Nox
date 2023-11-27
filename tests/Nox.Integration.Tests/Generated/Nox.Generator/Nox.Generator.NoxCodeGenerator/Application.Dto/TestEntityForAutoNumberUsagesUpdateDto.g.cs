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
/// Entity created for testing auto number usages.
/// </summary>
public partial class TestEntityForAutoNumberUsagesUpdateDto : TestEntityForAutoNumberUsagesUpdateDtoBase
{

}

/// <summary>
/// Patch entity TestEntityForAutoNumberUsages: Entity created for testing auto number usages.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class TestEntityForAutoNumberUsagesPatchDto: { { className} }
{

}

/// <summary>
/// Entity created for testing auto number usages
/// </summary>
public partial class TestEntityForAutoNumberUsagesUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.TestEntityForAutoNumberUsages>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
}