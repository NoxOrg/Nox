// Generated

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
public partial class TestEntityZeroOrOneUpdateDto : IEntityDto<DomainNamespace.TestEntityZeroOrOne>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    
    public System.String? SecondTestEntityZeroOrOneRelationshipId { get; set; } = default!;
}