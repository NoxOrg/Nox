﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using SecondTestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany;
namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipOneOrManyUpdateDto : IEntityDto<SecondTestEntityOwnedRelationshipOneOrManyEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public System.String TextTestField2 { get; set; } = default!;
}