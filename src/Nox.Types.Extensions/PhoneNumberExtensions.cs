using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions;

/// <summary>
/// Provides extension methods for <see cref="PhoneNumber"/> class.
/// </summary>
public static class PhoneNumberExtensions
{
    /// <summary>
    /// Retrieves the reference phone number information.
    /// </summary>
    /// <param name="phoneNumber">The phone number.</param>
    /// <returns>The reference phone number information.</returns>
    public static PhoneNumberInfo GetReferencePhoneNumberInfo(this PhoneNumber phoneNumber)
    {
        using var worldContext = new WorldContext();
        var phoneNumberInfo = worldContext.PhoneNumbers.GetPhoneNumberInfo(phoneNumber.Value);
        return phoneNumberInfo;
    }
}
