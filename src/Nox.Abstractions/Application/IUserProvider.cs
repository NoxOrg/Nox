using Nox.Types;

namespace Nox.Abstractions;

public interface IUserProvider
{
    User GetUser();
}