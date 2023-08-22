namespace Nox.Types;

public interface IPassword
{
    string HashedPassword { get; }
    string Salt { get; }
}