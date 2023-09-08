// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwner : AuditableEntityBase
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public Nox.Types.StreetAddress? StreetAddress { get; set; } = null!;

    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public Nox.Types.TranslatedText? LocalGreeting { get; set; } = null!;

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> StoreRel { get; set; } = new();
}