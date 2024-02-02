namespace Nox.Yaml.Tests.TestDesigns.Cli.models;

public class NoxJobDisplayMessage: ICloneable
{
    public string Success { get; set; } = string.Empty;
    public string IfCondition { get; set; } = string.Empty;
    public object Clone()
    {
        return new NoxJobDisplayMessage
        {
            Success = new string(Success),
            IfCondition = new string(IfCondition)
        };
    }
}