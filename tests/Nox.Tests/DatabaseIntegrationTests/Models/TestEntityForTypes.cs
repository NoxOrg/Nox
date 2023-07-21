// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityForTypes : AuditableEntityBase
{
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Text Id { get; set; } = null!;
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Text TextTestField { get; set; } = null!;
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Number NumberTestField { get; set; } = null!;
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public Money? MoneyTestField { get; set; } = null!;
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public CountryCode2? CountryCode2TestField { get; set; } = null!;
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public StreetAddress? StreetAddressTestField { get; set; } = null!;
    
    /// <summary>
    /// (Optional)
    /// </summary>
    public LanguageCode? LanguageCodeTestField { get; set; } = null!;
}
