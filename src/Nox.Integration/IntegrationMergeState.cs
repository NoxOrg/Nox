namespace Nox.Integration;

public class IntegrationMergeState
{
    public string SourceName { get; set; } = string.Empty;
    public string Property { get; set; } = string.Empty;
    
    public DateTime LastDateLoadedUtc { get; set; }
    public bool Updated { get; set; } = false;
}