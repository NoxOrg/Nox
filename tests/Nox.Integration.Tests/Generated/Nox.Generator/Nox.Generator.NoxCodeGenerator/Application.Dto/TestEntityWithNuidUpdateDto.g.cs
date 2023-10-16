// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApp.Domain;

using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;
namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuidUpdateDto : IEntityDto<TestEntityWithNuidEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
}