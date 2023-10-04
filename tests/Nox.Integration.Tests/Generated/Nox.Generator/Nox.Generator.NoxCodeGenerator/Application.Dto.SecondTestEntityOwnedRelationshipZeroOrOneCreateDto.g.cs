// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class SecondTestEntityOwnedRelationshipZeroOrOneCreateDto : SecondTestEntityOwnedRelationshipZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipZeroOrOneCreateDtoBase : IEntityDto<SecondTestEntityOwnedRelationshipZeroOrOneEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public virtual System.String TextTestField2 { get; set; } = default!;
}