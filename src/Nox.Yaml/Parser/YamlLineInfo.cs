namespace Nox.Yaml.Parser;

internal class YamlLineInfo
{
    public string FileName { get; private set; }
    public int Line { get; private set; }
    public string Text { get; private set; }

    public string? Comment { get; private set; }

    public YamlLineInfo(string fileName, int line, string text, string? comment = null)
    {
        FileName = fileName;
        Line = line;
        Text = text;
        Comment = comment;
    }

}
