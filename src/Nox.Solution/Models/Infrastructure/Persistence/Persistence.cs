
using Json.Schema.Generation;

namespace Nox.Solution
{
    public class Persistence
    {
        [Required]
        // These descriptors should be moved to the class when the generator is fixed
        [Title("The definition namespace for the Database server used in a Nox solution.")]
        [Description("Specify properties pertinent to the solution Database server here. Examples include name, serverUri, Port and connection credentials")]
        [AdditionalProperties(false)]
        public DatabaseServer DatabaseServer { get; internal set; } = new();

        public CacheServer? CacheServer { get; internal set; }

        public SearchServer? SearchServer { get; internal set; }

        public EventSourceServer? EventSourceServer { get; internal set; }
    }
}
