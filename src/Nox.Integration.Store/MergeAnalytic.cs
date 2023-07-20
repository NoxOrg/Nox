using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nox.Integration.Store;

public class MergeAnalytic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Inserts { get; set; }
    public int Updates { get; set; }
    public int Unchanged { get; set; }
    
}