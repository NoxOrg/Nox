using CryptocashIntegration.Application.Integrations;
using MediatR;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableRecordCreatedEventHandler: INotificationHandler<CountryQueryToCustomTableRecordCreatedEvent>
{
    private readonly ILogger _logger;

    public CountryQueryToCustomTableRecordCreatedEventHandler(ILogger<CountryQueryToCustomTableRecordCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CountryQueryToCustomTableRecordCreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (QueryToCustomTableRecordCreatedPayload)notification.Payload!;
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