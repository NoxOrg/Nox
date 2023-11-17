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
public partial class TestEntityOneOrManyCreateDto : TestEntityOneOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityOneOrMany>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
    /// </summary>
    public virtual List<System.String> SecondTestEntityOneOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<SecondTestEntityOneOrManyCreateDto> SecondTestEntityOneOrManies { get; set; } = new();
}