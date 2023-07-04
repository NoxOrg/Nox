namespace Nox.Solution;

public class IntegrationTargetWebApiOptions
{
    public string Route { get; set; } = string.Empty;
    public IntegrationWebApiRequestResponseFormat RequestFormat { get; set; } = IntegrationWebApiRequestResponseFormat.Json;
    public IntegrationTargetHttpVerb HttpVerb { get; set; } = IntegrationTargetHttpVerb.Post;
}