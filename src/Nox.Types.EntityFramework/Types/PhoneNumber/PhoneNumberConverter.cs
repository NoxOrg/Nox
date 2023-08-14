using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class PhoneNumberConverter : ValueConverter<PhoneNumber, string>
{
    public PhoneNumberConverter() : base(phoneNumber => phoneNumber.Value, phoneNumberValue => PhoneNumber.FromDatabase(phoneNumberValue)) { }
}