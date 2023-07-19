// Generated

#nullable enable

using Nox.Types;

namespace TestDatabaseWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntity : AuditableEntityBase
{
    /// <summary>
    /// (Optional)
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
}