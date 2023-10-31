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
    private string _integrationEventPropertyName = nameof(CloudEventMessage<IIntegrationEvent>.IntegrationEvent);
    private string _userPropertyName = nameof(CloudEventMessage<IIntegrationEvent>.User);
    private string _messagePrefixPropertyName = nameof(CloudEventMessage<IIntegrationEvent>.MessagePrefix);



    public CloudEventMessageSerializer(string platformId, string solutionName, string solutionVersion)
    {
        _platformId = platformId;
        _solutionName = solutionName;
        _solutionVersion = solutionVersion;
    }


public ContentType ContentType => new("application/cloudevents+json");

    public MessageBody GetMessageBody<T>(SendContext<T> sendContext) where T : class
    {
        var cloudEventMessageType = sendContext.Message.GetType();

        var integrationEvent = (IIntegrationEvent)cloudEventMessageType.GetProperty(_integrationEventPropertyName)!.GetValue(sendContext.Message)!;
        var user = (string)cloudEventMessageType.GetProperty(_userPropertyName)!.GetValue(sendContext.Message)!;
        var messagePrefix = (string)cloudEventMessageType.GetProperty(_messagePrefixPropertyName)!.GetValue(sendContext.Message)!;

        var integrationEventAttribute = integrationEvent.GetType().GetCustomAttribute<IntegrationEventTypeAttribute>();
        var trait = integrationEventAttribute?.Trait;
        var eventName = integrationEventAttribute?.EventName;
        if (string.IsNullOrWhiteSpace(trait))
        {
            throw new EventTraitIsNotFoundException($"Provided {nameof(integrationEventAttribute.Trait)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(eventName))
        {
            throw new EventNameIsNotFoundException($"Provided {nameof(integrationEventAttribute.EventName)} in {nameof(IntegrationEventTypeAttribute)} for event {integrationEvent.GetType()} can't be null or empty.");
        }
        var cloudEvent = new CloudEvent();
        cloudEvent.Data = integrationEvent;
        cloudEvent.Id = sendContext.MessageId.ToString();
        cloudEvent.Source = new System.Uri($"https://{messagePrefix}{_platformId}.com/{_solutionName}");
        cloudEvent.Time = sendContext.SentTime;
        cloudEvent.Type = $"{_platformId}.{_solutionName}.{trait}.v{_solutionVersion}.{eventName}";
        cloudEvent.DataSchema = new System.Uri($"https://{messagePrefix}{_platformId}.com/schemas/{_solutionName}/{trait}/v{_solutionVersion}/{eventName}.json");
        cloudEvent.SetAttributeFromString("xuserid", user);
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
