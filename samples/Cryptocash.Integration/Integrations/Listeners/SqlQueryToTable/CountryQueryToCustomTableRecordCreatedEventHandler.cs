using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class QueryToTableRecordCreatedEventHandler: INotificationHandler<QueryToTableRecordCreatedEvent>
{
    private readonly ILogger _logger;

    public QueryToTableRecordCreatedEventHandler(ILogger<QueryToTableRecordCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(QueryToTableRecordCreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToTableRecordCreatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               "Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n",
            "CountryQueryToTableEtlRecordCreatedEvent", payload, payload.Name, payload.Population);
        return Task.CompletedTask;
    }
}