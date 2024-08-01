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
public partial class ThirdTestEntityZeroOrManyCreateDto : ThirdTestEntityZeroOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrManyCreateDtoBase 
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
    /// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
    /// </summary>
    public virtual List<System.String> ThirdTestEntityOneOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<ThirdTestEntityOneOrManyCreateDto> ThirdTestEntityOneOrManies { get; set; } = new();
}