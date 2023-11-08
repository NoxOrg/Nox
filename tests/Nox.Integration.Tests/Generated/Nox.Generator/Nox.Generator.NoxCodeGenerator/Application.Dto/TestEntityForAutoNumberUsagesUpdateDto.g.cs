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
/// Entity created for testing auto number usages
/// </summary>
public partial class TestEntityForAutoNumberUsagesUpdateDto : IEntityDto<DomainNamespace.TestEntityForAutoNumberUsages>
{
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AutoNumberFieldWithOptions is required")]
    
    public System.Int64 AutoNumberFieldWithOptions { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "AutoNumberFieldWithoutOptions is required")]
    
    public System.Int64 AutoNumberFieldWithoutOptions { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public System.String TextField { get; set; } = default!;
}