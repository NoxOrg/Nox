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
/// Entity created for testing database.
/// </summary>
public partial class ThirdTestEntityOneOrManyCreateDto : ThirdTestEntityOneOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityOneOrManyCreateDtoBase : IEntityDto<DomainNamespace.ThirdTestEntityOneOrMany>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String? TextTestField { get; set; }

    /// <summary>
    /// ThirdTestEntityOneOrMany Test entity relationship to ThirdTestEntityZeroOrMany OneOrMany ThirdTestEntityZeroOrManies
    /// </summary>
    public virtual List<System.String> ThirdTestEntityZeroOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<ThirdTestEntityZeroOrManyCreateDto> ThirdTestEntityZeroOrManies { get; set; } = new();
}