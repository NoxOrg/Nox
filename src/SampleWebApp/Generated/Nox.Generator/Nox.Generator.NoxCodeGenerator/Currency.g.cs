// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of currencies.
/// </summary>
public partial class Currency : AuditableEntityBase
{
    
    /// <summary>
    /// The currency's primary key / identifier (required).
    /// </summary>
    public Text Id { get; set; } = null!;
    
    /// <summary>
    /// The currency's name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
    
    /// <summary>
    /// Currency is legal tender for ZeroOrMany Countries
    /// </summary>
    public virtual List<Country> Countries { get; set; } = null!;
    
    [NotMapped]
    public List<Country> CurrencyIsLegalTenderForCountry => Countries;
}
