// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuidCreateDto : TestEntityWithNuidCreateDtoBase
{

}

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public abstract class TestEntityWithNuidCreateDtoBase 
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
}