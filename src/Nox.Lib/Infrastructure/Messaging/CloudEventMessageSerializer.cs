using CloudNative.CloudEvents;
using CloudNative.CloudEvents.SystemTextJson;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Nox.Application;
using System.Net.Mime;
using System.Reflection;

namespace Nox.Infrastructure.Messaging;

internal sealed class CloudEventMessageSerializer : IMessageSerializer
{
    private readonly JsonEventFormatter _formatter = new JsonEventFormatter();
    private string _platformId;
    private string _solutionName;
    private string _solutionVersion;

    public CloudEventMessageSerializer(string platformId, string solutionName, string solutionVersion)
    {
        _platformId = platformId;
        _solutionName = solutionName;
        _solutionVersion = solutionVersion;
    }

public ContentType ContentType => new("application/cloudevents+json");

    public MessageBody GetMessageBody<T>(SendContext<T> sendContext) where T : class
    {       
        var cloudEventMessage = sendContext.Message as CloudEventMessage;
        var integrationEventAttribute = cloudEventMessage!.IntegrationEvent.GetType().GetCustomAttribute<IntegrationEventTypeAttribute>();
        var trait = integrationEventAttribute?.Trait;
        var eventName = integrationEventAttribute?.EventName;
        if (string.IsNullOrWhiteSpace(trait))
        {
            throw new EventTraitIsNotFoundException($"Provided {nameof(integrationEventAttribute.Trait)} in {nameof(IntegrationEventTypeAttribute)} for event {cloudEventMessage!.IntegrationEvent.GetType()} can't be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(eventName))
        {
            throw new EventNameIsNotFoundException($"Provided {nameof(integrationEventAttribute.EventName)} in {nameof(IntegrationEventTypeAttribute)} for event {cloudEventMessage!.IntegrationEvent.GetType()} can't be null or empty.");
        }
        var cloudEvent = new CloudEvent();
        cloudEvent.Data = cloudEventMessage.IntegrationEvent;
        cloudEvent.Id = sendContext.MessageId.ToString();
        cloudEvent.Source = new System.Uri($"https://{cloudEventMessage.MessagePrefix}{_platformId}.com/{_solutionName}");
        cloudEvent.Time = sendContext.SentTime;
        cloudEvent.Type = $"{_platformId}.{_solutionName}.{trait}.v{_solutionVersion}.{eventName}";
        cloudEvent.DataSchema = new System.Uri($"https://{cloudEventMessage.MessagePrefix}{_platformId}.com/schemas/{_solutionName}/{trait}/v{_solutionVersion}/{eventName}.json");
        //cloudEvent.SetAttributeFromString("xuserid", _userProvider.GetUser().ToString());
        cloudEvent.Validate();
        /*
         * xtenantid 
           xuserid 
           xapplicationid 
           xcorrelationid 
           xtraceid 
           xtraceparent 
           xinstanceid 
         */

        var result = new ArrayMessageBody(_formatter.EncodeStructuredModeMessage(cloudEvent!, out var contentType).ToArray());
        return result;
    }
}
