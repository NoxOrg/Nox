using CloudNative.CloudEvents;
using Nox.Application;
using System.Text.Json.Serialization;

namespace Nox.Infrastructure.Messaging
{
    /// <summary>
    /// Cloud Event witth an <see cref="IIntegrationEvent"/> event as its Data
    /// </summary>
    internal record class CloudEventMessage<T>(T Data) where T :IIntegrationEvent
    {
        [JsonPropertyName("specversion")]
        public string? SpecVersion { get; set; }
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("source")]
        public Uri? Source { get; set; }
        public string? Type { get; set; }
        [JsonPropertyName("datacontenttype")]
        public string? DataContentType { get; set; } = "application/json";
        public Uri? DataSchema { get; set; }
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }
        [JsonPropertyName("time")]
        public DateTimeOffset? Time { get; set; }
        [JsonPropertyName("xuserid")]
        public string? UserId { get; set; }

        internal void SetCloudEvent(CloudEvent cloudEvent)
        {
            SpecVersion = cloudEvent.SpecVersion.VersionId;
            Id = cloudEvent.Id;
            Source = cloudEvent.Source;
            Type = cloudEvent.Type;
            DataSchema = cloudEvent.DataSchema;
            Time = cloudEvent.Time;
            Subject = cloudEvent.Subject;
        }

#pragma warning disable S125 // Sections of code should not be commented out
                            //public string? xtenantid { get; set; }
                            //public string? xapplicationid { get; set; }
                            //public string? xcorrelationid { get; set; }
                            //public string? xtraceid { get; set; }
                            //public string? xtraceparent { get; set; }
                            //public string? xinstanceid { get; set; }
    }
#pragma warning restore S125 // Sections of code should not be commented out
}
