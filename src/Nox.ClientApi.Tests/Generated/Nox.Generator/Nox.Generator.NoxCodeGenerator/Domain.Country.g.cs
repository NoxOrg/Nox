﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Country Entity.
/// </summary>
public partial class Country : AuditableEntityBase, IConcurrent
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public Nox.Types.Money? CountryDebt { get; set; } = null!;

    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public Nox.Types.LanguageCode? FirstLanguageCode { get; set; } = null!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public String? ShortDescription
    { 
        get { return $"{Name} has a population of {Population} people."; }
        private set { }
    }

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalName> CountryLocalNames { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}