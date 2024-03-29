﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressUpsertDto : EmailAddressUpsertDtoBase
{

}

/// <summary>
/// Verified Email Address
/// </summary>
public abstract class EmailAddressUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Email     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Email { get; set; }

    /// <summary>
    /// Verified     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Boolean? IsVerified { get; set; }
}