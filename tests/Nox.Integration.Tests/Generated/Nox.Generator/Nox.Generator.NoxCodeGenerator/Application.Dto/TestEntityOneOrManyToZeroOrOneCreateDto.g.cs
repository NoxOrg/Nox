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
public partial class TestEntityOneOrManyToZeroOrOneCreateDto : TestEntityOneOrManyToZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToZeroOrOneCreateDtoBase 
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
    /// TestEntityOneOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToOneOrMany OneOrMany TestEntityZeroOrOneToOneOrManies
    /// </summary>
    public virtual List<System.String> TestEntityZeroOrOneToOneOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityZeroOrOneToOneOrManyCreateDto> TestEntityZeroOrOneToOneOrManies { get; set; } = new();
}