using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The user converter.
/// </summary>
public class UserConverter : ValueConverter<User, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserConverter"/> class.
    /// </summary>
    public UserConverter() : base(user => user.Value, userValue => User.FromDatabase(userValue)) { }
}
