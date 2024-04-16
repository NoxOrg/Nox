using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nox.Integration.Abstractions.Models;

public class MergeState
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [MaxLength(30)]
    public string? Integration { get; set; }
    
    [MaxLength(30)]
    public string? Property { get; set; }
    
    public DateTime LastDateLoadedUtc { get; set; }
    
    public bool IsUpdated { get; set; } = false;
}