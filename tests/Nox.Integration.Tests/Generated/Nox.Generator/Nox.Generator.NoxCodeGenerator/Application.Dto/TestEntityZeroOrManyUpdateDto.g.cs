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
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrManyUpdateDto : IEntityDto<DomainNamespace.TestEntityZeroOrMany>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrMany Test entity relationship to SecondTestEntityZeroOrMany ZeroOrMany SecondTestEntityZeroOrManies
    /// </summary>
    public List<System.String> SecondTestEntityZeroOrManyRelationshipId { get; set; } = new();
}