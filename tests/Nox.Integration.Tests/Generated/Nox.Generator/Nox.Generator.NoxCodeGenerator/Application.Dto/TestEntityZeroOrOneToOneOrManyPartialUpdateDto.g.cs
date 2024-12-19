﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;



/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityZeroOrOneToOneOrManyPartialUpdateDto : TestEntityZeroOrOneToOneOrManyPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing database
/// </summary>
public partial class TestEntityZeroOrOneToOneOrManyPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String TextTestField { get; set; } = default!;
}