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

public partial class ThirdTestEntityExactlyOneCreateDto : ThirdTestEntityExactlyOneCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class ThirdTestEntityExactlyOneCreateDtoBase : IEntityDto<ThirdTestEntityExactlyOne>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// ThirdTestEntityExactlyOne Test entity relationship to ThirdTestEntityZeroOrOne ExactlyOne ThirdTestEntityZeroOrOnes
    /// </summary>
    public System.String? ThirdTestEntityZeroOrOneRelationshipId { get; set; } = default!;
    public virtual ThirdTestEntityZeroOrOneCreateDto? ThirdTestEntityZeroOrOneRelationship { get; set; } = default!;
}