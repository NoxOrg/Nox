namespace Nox.Yaml.Tests.TestDesigns.Cli.Models;

public class NoxActionDisplayMessage
{
    public string Success { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
    public string IfCondition { get; set; } = string.Empty;
    public object Clone()
    {
        return new NoxActionDisplayMessage
        {
            Success = new string(Success),
            Error = new string(Error),
            IfCondition = new string(IfCondition)
        };
    }
}