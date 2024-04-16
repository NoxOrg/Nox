using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableRecordUpdatedEventHandler: INotificationHandler<JsonToTableRecordUpdatedEvent>
{
    private readonly ILogger _logger;

    public JsonToTableRecordUpdatedEventHandler(ILogger<QueryToTableRecordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(JsonToTableRecordUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (JsonToTableRecordUpdatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               //"Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "JsonToTableRecordUpdatedEvent", payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}