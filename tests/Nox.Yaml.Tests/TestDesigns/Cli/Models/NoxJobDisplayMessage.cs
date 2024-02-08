namespace Nox.Yaml.Tests.TestDesigns.Cli.Models;

public class NoxJobDisplayMessage
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