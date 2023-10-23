﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityZeroOrOneCreateDto : TestEntityZeroOrOneCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneCreateDtoBase : IEntityDto<TestEntityZeroOrOneEntity>
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
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public System.String? SecondTestEntityZeroOrOneRelationshipId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual SecondTestEntityZeroOrOneCreateDto? SecondTestEntityZeroOrOneRelationship { get; set; } = default!;
}