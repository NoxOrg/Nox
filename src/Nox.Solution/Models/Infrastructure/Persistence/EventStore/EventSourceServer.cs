using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the Event Source server used in a Nox solution.")]
    [Description("Specify properties pertinent to the solution Event Source server here. Examples include name, serverUri, Port and connection credentials")]
    [AdditionalProperties(false)]
    public class EventSourceServer: ServerBase
    {
        [Required]
        [Title("The event source server provider.")]
        [Description("The provider used for this event source server. Examples include EventStoreDB.")]
        public EventSourceServerProvider Provider { get; internal set; } = EventSourceServerProvider.EventStoreDb;
    }
}