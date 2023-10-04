// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityZeroOrManyToOneOrManyCreateDto : TestEntityZeroOrManyToOneOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityZeroOrManyToOneOrManyCreateDtoBase : IEntityDto<TestEntityZeroOrManyToOneOrMany>
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
    /// TestEntityZeroOrManyToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrMany ZeroOrMany TestEntityOneOrManyToZeroOrManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<TestEntityOneOrManyToZeroOrManyCreateDto> TestEntityOneOrManyToZeroOrMany { get; set; } = new();
}