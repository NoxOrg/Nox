﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;



/// <summary>
/// Tenant.
/// </summary>
public partial class TenantPartialUpdateDto : TenantPartialUpdateDtoBase
{

}

/// <summary>
/// Tenant
/// </summary>
public partial class TenantPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Teanant Name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Tenant Status
    /// </summary>
    public virtual System.Int32? Status { get; set; }
}