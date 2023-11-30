namespace Nox.Types;

public interface IHashedText
{
    string HashText { get; }
    string Salt { get; }
}
public interface IWritableHashedText
{
    string HashText { set; }
    string Salt { set; }
}