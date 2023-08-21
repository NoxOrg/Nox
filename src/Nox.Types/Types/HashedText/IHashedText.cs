namespace Nox.Types;

public interface IHashedText
{
    string HashText { get; }
    string Salt { get; }
}