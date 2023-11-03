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
/// .
/// </summary>
public partial class SecondTestEntityExactlyOneUpdateDto : IEntityDto<DomainNamespace.SecondTestEntityExactlyOne>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField2 is required")]
    
    public System.String TextTestField2 { get; set; } = default!;

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    [Required(ErrorMessage = "TestEntityExactlyOne is required")]
    public System.String TestEntityExactlyOneId { get; set; } = default!;
}