namespace Nox.Types;

public interface IImage
{
    string PrettyName { get; }
    int SizeInBytes { get; }
    string Url { get; }
}
public interface IWritableImage
{
    string PrettyName { set; }
    int SizeInBytes { set; }
    string Url { set; }
}