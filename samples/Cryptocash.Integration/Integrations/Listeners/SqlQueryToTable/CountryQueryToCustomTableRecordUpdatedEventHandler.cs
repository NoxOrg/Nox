using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class QueryToTableRecordUpdatedEventHandler: INotificationHandler<QueryToTableRecordUpdatedEvent>
{
    private readonly ILogger _logger;

    public QueryToTableRecordUpdatedEventHandler(ILogger<QueryToTableRecordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(QueryToTableRecordUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToTableRecordCreatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               //"Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n",
            "CountryQueryToCustomTableEtlRecordUpdatedEvent", payload.Name, payload.Population);
        return Task.CompletedTask;
    }
}