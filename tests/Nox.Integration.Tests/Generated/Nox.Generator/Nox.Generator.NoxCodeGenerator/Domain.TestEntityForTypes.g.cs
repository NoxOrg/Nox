// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class TestEntityForTypes : TestEntityForTypesBase, IEntityHaveDomainEvents
{
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
}
/// <summary>
/// Record for TestEntityForTypes created event.
/// </summary>
internal record TestEntityForTypesCreated(TestEntityForTypes TestEntityForTypes) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForTypes updated event.
/// </summary>
internal record TestEntityForTypesUpdated(TestEntityForTypes TestEntityForTypes) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityForTypes deleted event.
/// </summary>
internal record TestEntityForTypesDeleted(TestEntityForTypes TestEntityForTypes) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class TestEntityForTypesBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Number NumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Money? MoneyTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CountryCode2? CountryCode2TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.StreetAddress? StreetAddressTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CurrencyCode3? CurrencyCode3TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DayOfWeek? DayOfWeekTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.JwtToken? JwtTokenTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.LatLong? GeoCoordTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Area? AreaTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.TimeZoneCode? TimeZoneCodeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Boolean? BooleanTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CountryCode3? CountryCode3TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CountryNumber? CountryNumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CurrencyNumber? CurrencyNumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DateTime? DateTimeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DateTimeRange? DateTimeRangeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Distance? DistanceTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Email? EmailTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.EncryptedText? EncryptedTextTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Guid? GuidTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.HashedText? HashedTextTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.InternetDomain? InternetDomainTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.IpAddress? IpAddressV4TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.IpAddress? IpAddressV6TestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Json? JsonTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Length? LengthTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.MacAddress? MacAddressTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Month? MonthTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Password? PasswordTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Percentage? PercentageTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.PhoneNumber? PhoneNumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Temperature? TemperatureTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.TranslatedText? TranslatedTextTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Uri? UriTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Volume? VolumeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Weight? WeightTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Year? YearTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.CultureCode? CultureCodeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.LanguageCode? LanguageCodeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Yaml? YamlTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DateTimeDuration? DateTimeDurationTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Time? TimeTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Date? DateTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Markdown? MarkdownTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.File? FileTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Color? ColorTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Url? UrlTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.DateTimeSchedule? DateTimeScheduleTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.User? UserTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public int? FormulaTestField
    { 
        get { return 2 + 2; }
        private set { }
    }

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber AutoNumberTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Html? HtmlTestField { get; set; } = null!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public Nox.Types.Image? ImageTestField { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

    protected virtual void InternalRaiseCreateEvent(TestEntityForTypes testEntityForTypes)
    {
        InternalDomainEvents.Add(new TestEntityForTypesCreated(testEntityForTypes));
    }
	
    protected virtual void InternalRaiseUpdateEvent(TestEntityForTypes testEntityForTypes)
    {
        InternalDomainEvents.Add(new TestEntityForTypesUpdated(testEntityForTypes));
    }
	
    protected virtual void InternalRaiseDeleteEvent(TestEntityForTypes testEntityForTypes)
    {
        InternalDomainEvents.Add(new TestEntityForTypesDeleted(testEntityForTypes));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}