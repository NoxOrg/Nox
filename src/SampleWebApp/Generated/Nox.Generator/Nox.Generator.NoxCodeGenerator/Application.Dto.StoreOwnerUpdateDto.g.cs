﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerUpdateDto
{
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
}