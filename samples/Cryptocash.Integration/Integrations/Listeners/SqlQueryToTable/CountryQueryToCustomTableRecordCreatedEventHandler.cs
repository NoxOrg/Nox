using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableRecordCreatedEventHandler: INotificationHandler<QueryToCustomTableRecordCreatedEvent>
{
    private readonly ILogger _logger;

    public QueryToCustomTableRecordCreatedEventHandler(ILogger<QueryToCustomTableRecordCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(QueryToCustomTableRecordCreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToCustomTableRecordCreatedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               "Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "CountryQueryToCustomTableEtlRecordCreatedEvent", payload.Id, payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}