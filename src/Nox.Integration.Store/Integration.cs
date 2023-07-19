using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nox.Integration.Store;

public class Integration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Definition { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }
    public virtual ICollection<MergeState>? MergeStates { get; set; }
}