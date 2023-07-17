using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nox.Integration.Store;

public class MergeState
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Property { get; set; } = string.Empty;
    
    public DateTime LastDateLoadedUtc { get; set; }
    
    public bool Updated { get; set; } = false;
}