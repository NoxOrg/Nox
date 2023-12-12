using System.ComponentModel.DataAnnotations;

namespace Nox.Integration.Abstractions.Models;

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