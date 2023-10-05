// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class ThirdTestEntityZeroOrOneCreateDto : ThirdTestEntityZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class ThirdTestEntityZeroOrOneCreateDtoBase : IEntityDto<ThirdTestEntityZeroOrOneEntity>
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
    /// ThirdTestEntityZeroOrOne Test entity relationship to ThirdTestEntityExactlyOne ZeroOrOne ThirdTestEntityExactlyOnes
    /// </summary>
    public System.String? ThirdTestEntityExactlyOneRelationshipId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual ThirdTestEntityExactlyOneCreateDto? ThirdTestEntityExactlyOneRelationship { get; set; } = default!;
}