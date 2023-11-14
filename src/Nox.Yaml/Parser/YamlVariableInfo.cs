namespace Nox.Yaml.Parser;

internal class YamlVariableInfo
{
    public string Type { get; }
    public string Name { get; }
    public int Index { get; }
    public int Length { get; }

    public YamlVariableInfo(string type, string name, int index, int length)
    {
        Type = type;
        Name = name;
        Index = index;
        Length = length;
    }
}
