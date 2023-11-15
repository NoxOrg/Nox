// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneToOneOrManyCreateDto : TestEntityZeroOrOneToOneOrManyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToOneOrManyCreateDtoBase : IEntityDto<DomainNamespace.TestEntityZeroOrOneToOneOrMany>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrOneToOneOrMany Test entity relationship to TestEntityOneOrManyToZeroOrOne ZeroOrOne TestEntityOneOrManyToZeroOrOnes
    /// </summary>
    public System.String? TestEntityOneOrManyToZeroOrOneId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TestEntityOneOrManyToZeroOrOneCreateDto? TestEntityOneOrManyToZeroOrOne { get; set; } = default!;
}