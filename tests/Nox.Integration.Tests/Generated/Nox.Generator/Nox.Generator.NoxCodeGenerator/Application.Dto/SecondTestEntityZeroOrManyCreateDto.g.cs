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
/// .
/// </summary>
public partial class SecondTestEntityZeroOrManyCreateDto : SecondTestEntityZeroOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityZeroOrManyCreateDtoBase : IEntityDto<DomainNamespace.SecondTestEntityZeroOrMany>
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
    /// SecondTestEntityZeroOrMany Test entity relationship to TestEntityZeroOrMany ZeroOrMany TestEntityZeroOrManies
    /// </summary>
    public virtual List<System.String> TestEntityZeroOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityZeroOrManyCreateDto> TestEntityZeroOrManies { get; set; } = new();
}