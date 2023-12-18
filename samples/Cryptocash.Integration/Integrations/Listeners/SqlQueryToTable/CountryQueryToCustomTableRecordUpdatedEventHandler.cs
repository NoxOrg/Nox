using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableRecordUpdatedEventHandler: INotificationHandler<QueryToCustomTableRecordUpdatedEvent>
{
    private readonly ILogger _logger;

    public QueryToCustomTableRecordUpdatedEventHandler(ILogger<QueryToCustomTableRecordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(QueryToCustomTableRecordUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToCustomTableRecordCreatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               //"Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "CountryQueryToCustomTableEtlRecordUpdatedEvent", payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}