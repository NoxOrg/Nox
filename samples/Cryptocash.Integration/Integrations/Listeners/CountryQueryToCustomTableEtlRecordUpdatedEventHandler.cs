using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableRecordUpdatedEventHandler: INotificationHandler<CountryQueryToCustomTableRecordUpdatedEvent>
{
    private readonly ILogger _logger;

    public CountryQueryToCustomTableRecordUpdatedEventHandler(ILogger<CountryQueryToCustomTableRecordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CountryQueryToCustomTableRecordUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToCustomTableRecordCreatedPayload)notification.Payload!;
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