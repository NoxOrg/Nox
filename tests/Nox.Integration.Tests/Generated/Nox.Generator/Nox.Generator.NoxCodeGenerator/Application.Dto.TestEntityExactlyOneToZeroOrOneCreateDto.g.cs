﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityExactlyOneToZeroOrOneCreateDto : TestEntityExactlyOneToZeroOrOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrOneCreateDtoBase : IEntityDto<TestEntityExactlyOneToZeroOrOneEntity>
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
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    public System.String? TestEntityZeroOrOneToExactlyOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TestEntityZeroOrOneToExactlyOneCreateDto? TestEntityZeroOrOneToExactlyOne { get; set; } = default!;
}