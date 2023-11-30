namespace Nox.Types;

public interface IFile
{
    string PrettyName { get; }
    ulong SizeInBytes { get; }
    string Url { get; }
}
public interface IWritableFile
{
    string PrettyName { set; }
    ulong SizeInBytes { set; }
    string Url { set; }
}