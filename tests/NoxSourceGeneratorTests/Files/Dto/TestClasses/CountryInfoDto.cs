using Nox.Core.Interfaces.Entity;
using Nox.Types;

namespace NoxSourceGeneratorTests.Files.Dto.TestClasses;

/// <summary>
/// Dto for country information.
/// </summary>
public class CountryInfoDto: IDynamicDto
{
    /// <summary>
    /// The identity of the country, the Iso Alpha 2 code.
    /// </summary>
    public CountryCode2 CountryId { get; set; }
    
    /// <summary>
    /// The name of the country.
    /// </summary>
    public Text CountryName { get; set; }
}