using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultUserProvider : IUserProvider
{
    public User GetUser() => User.From(System.Guid.Empty.ToString());
}