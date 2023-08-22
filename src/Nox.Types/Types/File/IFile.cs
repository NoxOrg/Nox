namespace Nox.Types;

public interface IFile
{
    string PrettyName { get; }
    ulong SizeInBytes { get; }
    string Url { get; }
}