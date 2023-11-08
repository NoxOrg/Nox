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

public partial class TestEntityOwnedRelationshipExactlyOneCreateDto : TestEntityOwnedRelationshipExactlyOneCreateDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipExactlyOneCreateDtoBase : IEntityDto<DomainNamespace.TestEntityOwnedRelationshipExactlyOne>
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
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
    public virtual SecondTestEntityOwnedRelationshipExactlyOneCreateDto SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;
}