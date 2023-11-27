using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Nox.Integration;

public class IntegrationMergeState
{
    public long Id { get; set; }
    
    [MaxLength(30)]
    public string? Integration { get; set; }
    
    [MaxLength(30)]
    public string? Property { get; set; }
    
    public DateTime LastDateLoadedUtc { get; set; }
    
    public bool IsUpdated { get; set; } = false;
}