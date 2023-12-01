namespace Nox.Types;

public interface ITranslatedText
{
    string Phrase { get; }
    string CultureCode { get; }
}
public interface IWritableTranslatedText
{
    string Phrase { set; }
    string CultureCode { set; }
}