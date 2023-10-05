// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityOneOrManyToExactlyOneCreateDto : TestEntityOneOrManyToExactlyOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOneOrManyToExactlyOneCreateDtoBase : IEntityDto<TestEntityOneOrManyToExactlyOneEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<TestEntityExactlyOneToOneOrManyCreateDto> TestEntityExactlyOneToOneOrMany { get; set; } = new();
}