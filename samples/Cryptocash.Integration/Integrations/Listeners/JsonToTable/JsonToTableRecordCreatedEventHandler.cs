using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableRecordCreatedEventHandler: INotificationHandler<JsonToTableRecordCreatedEvent>
{
    private readonly ILogger _logger;

    public JsonToTableRecordCreatedEventHandler(ILogger<QueryToTableRecordCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(JsonToTableRecordCreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (JsonToTableRecordCreatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               "Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "JsonToTableRecordCreatedEvent", payload.Id, payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}