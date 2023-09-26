using Nox.Application;

namespace Nox.Messaging
{
    /// <summary>
    /// Default Nox implementation for the cloud event envelop with an <see cref="IIntegrationEvent"/> as the payload."/>
    /// </summary>
    public record class CloudEventRecord<T>(T Data)
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
        public string? xtenantid { get; set; }
        public string? xuserid { get; set; }
        public string? xapplicationid { get; set; }
        public string? xcorrelationid { get; set; }
        public string? xtraceid { get; set; }
        public string? xtraceparent { get; set; }
        public string? xinstanceid { get; set; }

#pragma warning restore IDE1006 // Naming Styles

    }

}
