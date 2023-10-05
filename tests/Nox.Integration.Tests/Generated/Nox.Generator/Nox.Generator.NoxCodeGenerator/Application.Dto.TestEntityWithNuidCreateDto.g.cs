// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;
using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityWithNuidCreateDto : TestEntityWithNuidCreateDtoBase
{

}

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public abstract class TestEntityWithNuidCreateDtoBase : IEntityDto<TestEntityWithNuidEntity>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
}