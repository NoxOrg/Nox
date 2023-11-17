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
/// Entity created for testing auto number usages.
/// </summary>
public partial class TestEntityForAutoNumberUsagesCreateDto : TestEntityForAutoNumberUsagesCreateDtoBase
{

}

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
public abstract class TestEntityForAutoNumberUsagesCreateDtoBase : IEntityDto<DomainNamespace.TestEntityForAutoNumberUsages>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextField is required")]
    
    public virtual System.String TextField { get; set; } = default!;
}