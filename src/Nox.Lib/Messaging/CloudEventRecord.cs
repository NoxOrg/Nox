using Nox.Application;

namespace Nox.Messaging
{
    public record class CloudEventRecord<T>(T Data) where T : IIntegrationEvent
    {
#pragma warning disable IDE1006 // Naming Styles
        public string? specversion { get; set; }
        public string? id { get; set; }
        public Uri? source { get; set; }
        public string? type { get; set; }
        public string? datacontenttype { get; set; } = "application/json";
        public Uri? dataschema { get; set; }
        public string? subject { get; set; }
        public DateTimeOffset? time { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

}
