namespace Nox.Types;

public interface IImage
{
    string PrettyName { get; }
    int SizeInBytes { get; }
    string Url { get; }
}