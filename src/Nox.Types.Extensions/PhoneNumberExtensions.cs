using Nox.Reference;

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
        var phoneNumberInfo = World.PhoneNumbers.GetPhoneNumberInfo(phoneNumber.Value);
        return phoneNumberInfo;
    }
}
