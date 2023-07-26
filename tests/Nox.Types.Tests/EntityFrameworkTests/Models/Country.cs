namespace Nox.Types.Tests.EntityFrameworkTests;

public class CountryId : ValueObject<int, CountryId>
{ }
/// <summary>
/// The country.
/// </summary>

public sealed class Country
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public CountryId Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public Text Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the info email.
    /// </summary>
    public Email InfoEmail { get; set; } = null!;

    /// <summary>
    /// Gets or sets the guid user.
    /// </summary>
    public User GuidUser { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email user.
    /// </summary>
    public User EmailUser { get; set; } = null!;

    /// <summary>
    /// Gets or sets the string user.
    /// </summary>
    public User StringUser { get; set; } = null!;

    /// <summary>
    /// Gets or sets the population.
    /// </summary>
    public Number? Population { get; set; } = null!;

    /// <summary>
    /// Gets or sets the latitude and longitude.
    /// </summary>
    public LatLong LatLong { get; set; } = null!;

    /// <summary>
    /// Gets or sets the gross domestic product(GDP).
    /// </summary>
    public Money GrossDomesticProduct { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country ISO code.
    /// </summary>
    public CountryCode2 CountryCode2 { get; set; } = null!;

    /// <summary>
    /// Gets or sets the area in square Kilometers.
    /// </summary>
    public Area AreaInSqKm { get; set; } = null!;

    /// <summary>
    /// Gets or sets the culture.
    /// </summary>
    public CultureCode CultureCode { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country number.
    /// </summary>
    public CountryNumber CountryNumber { get; set; } = null!;

    /// <summary>
    /// Gets or sets the month when the most tourists come to the country.
    /// </summary>
    public Month MonthOfPeakTourism { get; set; } = null!;

    /// <summary>
    /// Gets or sets the distance in kilometers.
    /// </summary>
    public Distance DistanceInKm { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date time range.
    /// </summary>
    public DateTimeRange DateTimeRange { get; set; } = null!;

    /// <summary>
    /// Gets or sets the internet domain associated with the country.
    /// </summary>
    public InternetDomain InternetDomain { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country ISO 3 code.
    /// </summary>
    public CountryCode3 CountryCode3 { get; set; } = null!;

    /// <summary>
    /// Gets or sets the IP Address.
    /// </summary>
    public IpAddress IPAddress { get; set; } = null!;

    /// <summary>
    /// Gets or sets the longest hiking trail in meters.
    /// </summary>
    public Length LongestHikingTrailInMeters { get; set; } = null!;

    /// <summary>
    /// Gets or sets the StreetAddress.
    /// </summary>
    public StreetAddress StreetAddress { get; set; } = null!;

    /// <summary>
    /// Gets or sets the mac address.
    /// </summary>
    public MacAddress MACAddress { get; set; } = null!;

    /// <summary>
    /// Gets or sets the uri.
    /// </summary>
    public Uri Uri { get; set; } = null!;

    /// <summary>
    /// Gets or sets the url.
    /// </summary>
    public Url Url { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    public Date Date { get; set; } = null!;

    /// <summary>
    /// Gets or sets the StreetAddress as Json.
    /// </summary>
    public Json StreetAddressJson { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Local Time Zone.
    /// </summary>
    public TimeZoneCode LocalTimeZone { get; set; } = null!;

    /// <summary>
    /// Gets or sets the IsLandlocked property.
    /// </summary>
    public Boolean IsLandLocked { get; set; } = null!;

    /// <summary>
    /// Gets or sets the duration of the date time.
    /// </summary>
    public DateTimeDuration DateTimeDuration { get; set; } = null!;

    /// <summary>
    /// Gets or sets the volume in cubic meters.
    /// </summary>
    public Volume VolumeInCubicMeters { get; set; } = null!;

    /// <summary>
    /// Gets or sets the weight in kilograms.
    /// </summary>
    public Weight WeightInKilograms { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Nuid.
    /// </summary>
    public Nuid Nuid { get; set; } = null!;

    /// <summary>
    /// Gets or sets hashed value
    /// </summary>
    public HashedText HashedText { get; set; } = null!;

    /// <summary>
    /// Gets or Sets db record create date
    /// </summary>
    public DateTime? CreateDate { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name in Arabic Locale.
    /// </summary>
    public TranslatedText ArabicName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the current time.
    /// </summary>
    public Time CurrentTime { get; set; } = null!;

    /// <summary>
    /// Gets or sets the AverageTemperature.
    /// </summary>
    public Temperature? AverageTemperatureInCelsius { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Flag.
    /// </summary>
    public Image Flag { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country's description.
    /// </summary>
    public Markdown Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the country's webpage.
    /// </summary>
    public Html PageHtml { get; set; } = null!;

    /// <summary>
    /// Gets or sets the CitiesCounties.
    /// </summary>
    public Yaml CitiesCounties { get; set; } = null!;

    /// <summary>
    /// Gets or sets the file.
    /// </summary>
    public File File { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public PhoneNumber PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Gets or sets the SecretPassword.
    /// </summary>
    public EncryptedText SecretPassword { get; set; } = null!;

    /// <summary>
    /// Gets or sets the MainId property.
    /// </summary>
    public DatabaseNumber DatabaseId { get; set; } = null!;

    /// <summary>
    /// Gets or sets password
    /// </summary>
    public Password Password { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the currency number.
    /// </summary>
    public CurrencyNumber CurrencyNumber { get; set; } = null!;
}
