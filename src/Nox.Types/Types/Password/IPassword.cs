namespace Nox.Types;

public interface IPassword
{
    string HashedPassword { get; }
    string Salt { get; }
}
public interface IWritablePassword
{
    string HashedPassword { set; }
    string Salt { set; }
}