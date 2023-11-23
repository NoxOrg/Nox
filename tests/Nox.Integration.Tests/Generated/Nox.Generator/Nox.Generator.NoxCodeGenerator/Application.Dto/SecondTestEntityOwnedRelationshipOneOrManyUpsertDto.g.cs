﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// .
/// </summary>
public partial class SecondTestEntityOwnedRelationshipOneOrManyUpsertDto : SecondTestEntityOwnedRelationshipOneOrManyUpsertDtoBase
{

}

/// <summary>
/// 
/// </summary>
public abstract class SecondTestEntityOwnedRelationshipOneOrManyUpsertDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.SecondTestEntityOwnedRelationshipOneOrMany>
{

    /// <summary>
    /// 
    /// </summary>
    public System.String? Id { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TextTestField2 is required")]
    public virtual System.String TextTestField2 { get; set; } = default!;
}