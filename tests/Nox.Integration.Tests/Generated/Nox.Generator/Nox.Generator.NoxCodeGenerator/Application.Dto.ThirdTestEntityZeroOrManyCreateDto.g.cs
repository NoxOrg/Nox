﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class ThirdTestEntityZeroOrManyCreateDto : ThirdTestEntityZeroOrManyCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrManyCreateDtoBase : IEntityDto<ThirdTestEntityZeroOrManyEntity>
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
    /// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<ThirdTestEntityOneOrManyCreateDto> ThirdTestEntityOneOrManyRelationship { get; set; } = new();
}