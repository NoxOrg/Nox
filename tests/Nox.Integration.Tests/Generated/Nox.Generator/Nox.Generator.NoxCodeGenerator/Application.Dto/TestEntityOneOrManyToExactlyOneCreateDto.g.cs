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
public partial class TestEntityOneOrManyToExactlyOneCreateDto : TestEntityOneOrManyToExactlyOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToExactlyOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityOneOrManyToExactlyOne>
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
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
    /// </summary>
    public virtual List<System.String> TestEntityExactlyOneToOneOrManiesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<TestEntityExactlyOneToOneOrManyCreateDto> TestEntityExactlyOneToOneOrManies { get; set; } = new();
}