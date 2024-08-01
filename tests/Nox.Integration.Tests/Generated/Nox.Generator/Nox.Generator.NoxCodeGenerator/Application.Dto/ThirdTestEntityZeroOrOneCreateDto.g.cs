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
/// .
/// </summary>
public partial class ThirdTestEntityZeroOrOneCreateDto : ThirdTestEntityZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrOneCreateDtoBase 
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String? TextTestField2 { get; set; }

    /// <summary>
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public System.String? ThirdTestEntityExactlyOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ThirdTestEntityExactlyOneCreateDto? ThirdTestEntityExactlyOne { get; set; } = default!;
}