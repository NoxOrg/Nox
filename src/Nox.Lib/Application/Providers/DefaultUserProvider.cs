using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultUserProvider : IUserProvider
{
    public string GetUser() => System.Guid.Empty.ToString();
}