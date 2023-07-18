using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The email converter.
/// </summary>
public class EmailConverter : ValueConverter<Email, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailConverter"/> class.
    /// </summary>
    public EmailConverter() : base(emailAddress => emailAddress.Value, emailAddressValue => Email.FromDatabase(emailAddressValue)) { }
}
